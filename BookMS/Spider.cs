using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookMS {


    public class Spider {
        public struct BookHtmlContent {
            public string Title { get; set; }
            public string Url { get; set; }
            public string? Rate { get; set; }
            public string Subjects { get; set; }
            public string? Detail { get; set; }
        }

        private List<BookHtmlContent> _bookHtmlContents;
        public IEnumerable<BookHtmlContent> BookHtmlContents { get => _bookHtmlContents; }

        public Spider() => _bookHtmlContents = new List<BookHtmlContent>();

        private async static Task<string> GetResponse(string book) {
            book = HttpUtility.UrlEncode(book);
            string doubanUrl = $"https://www.douban.com/search?cat=1001&q={book}";
            using HttpClient client = new HttpClient();
            // 火狐
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0");
            HttpResponseMessage response = await client.GetAsync(doubanUrl);

            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : throw new Exception("请求http未成功");
        }

        /// <summary>
        /// 生成实例之后调用此方法
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task ParseHtml(string book) {
            HtmlDocument document = new HtmlDocument();
            string result = await GetResponse(book);
            document.LoadHtml(result);
            var bookNodes = document.DocumentNode.SelectNodes("//div[@class=\"result-list\"]/div[@class=\"result\"]/div[@class=\"content\"]");

            foreach (var node in bookNodes) {
                if (node == null) throw new Exception("结点为空");
                var titleNode = node.SelectSingleNode("div[@class=\"title\"]");
                string title = titleNode.SelectSingleNode("h3/a").InnerText;
                string url = titleNode.SelectSingleNode("h3/a").Attributes["href"].Value;

                var ratingNode = titleNode.SelectSingleNode("div[@class=\"rating-info\"]");
                string? rating = ratingNode.SelectSingleNode("span[@class=\"rating_nums\"]")?.InnerText;
                string subjects = ratingNode.SelectSingleNode("span[@class=\"subject-cast\"]").InnerText;

                string? detail = node.SelectSingleNode("p")?.InnerText;

                _bookHtmlContents.Add(new BookHtmlContent() {
                    Title = title,
                    Url = url,
                    Rate = rating,
                    Subjects = subjects,
                    Detail = detail,
                });
            }
        }
    }
}
