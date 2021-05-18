using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookMS {


    public class Spider {
        private struct DoubanJson {
            public string[] items;
            public int total;
            public int limit;
            public bool more;
        }

        public struct BookHtmlContent {
            public string Title { get; set; }
            public string Url { get; set; }
            public string? Rate { get; set; }
            public string Subjects { get; set; }
            public string? Detail { get; set; }
        }
        /// <summary>
        /// 是否含有更多条目
        /// </summary>
        public bool HasMore { get; private set; }
        public IEnumerable<BookHtmlContent> BookHtmlContents { get => _bookHtmlContents; }

        public Spider() => _bookHtmlContents = new List<BookHtmlContent>();

        private readonly List<BookHtmlContent> _bookHtmlContents;


        private async static Task<string> GetResponse(string book) {
            book = HttpUtility.UrlEncode(book);
            string doubanUrl = $"https://www.douban.com/j/search?q={book}&start=0&cat=1001";
            using HttpClient client = new HttpClient();
            // 火狐
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0");
            HttpResponseMessage response = await client.GetAsync(doubanUrl);

            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : throw new Exception("请求http未成功");
        }

        /// <summary>
        /// 异步方法，调用时需要使用await等待。此函数是一个异步的构造函数，接受一本书作为关键字，调用这个函数后可以获取BookHtmlContents的属性内容，否则为空
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task ParseHtml(string book) {
            string result = await GetResponse(book);
            DoubanJson doubanJson = JsonConvert.DeserializeObject<DoubanJson>(result);
            // 是否有更多
            HasMore = doubanJson.more;
            // 获取所有查询到的书目进行Html解码
            List<string> items = new List<string>();
            foreach (string item in doubanJson.items)
                items.Add(HttpUtility.HtmlDecode(item));

            foreach (string item in items) {
                HtmlDocument itemDocument = new HtmlDocument();
                itemDocument.LoadHtml(item);
                var itemNode = itemDocument.DocumentNode.SelectSingleNode("//div[@class=\"result\"]/div[@class=\"content\"]");
                if (itemNode == null) throw new Exception("未查询到关键词所对应的书");

                var titleNode = itemNode.SelectSingleNode("div[@class=\"title\"]");
                string title = titleNode.SelectSingleNode("h3/a").InnerText;
                string url = titleNode.SelectSingleNode("h3/a").Attributes["href"].Value;

                var ratingNode = titleNode.SelectSingleNode("div[@class=\"rating-info\"]");
                string? rating = ratingNode.SelectSingleNode("span[@class=\"rating_nums\"]")?.InnerText;
                string subjects = ratingNode.SelectSingleNode("span[@class=\"subject-cast\"]").InnerText;

                string? detail = itemNode.SelectSingleNode("p")?.InnerText;

                _bookHtmlContents.Add(new BookHtmlContent() {
                    Title = title,
                    Url = url,
                    Rate = rating,
                    Subjects = subjects,
                    Detail = detail,
                });
            }

            //HtmlDocument document = new HtmlDocument();
            //document.LoadHtml(result);
            //var bookNodes = document.DocumentNode.SelectNodes("//div[@class=\"result-list\"]/div[@class=\"result\"]/div[@class=\"content\"]");
            //if (bookNodes == null) throw new Exception("未查询到关键词所对应的书");

            //foreach (var node in bookNodes) {
            //    if (node == null) throw new Exception("结点为空");
            //    var titleNode = node.SelectSingleNode("div[@class=\"title\"]");
            //    string title = titleNode.SelectSingleNode("h3/a").InnerText;
            //    string url = titleNode.SelectSingleNode("h3/a").Attributes["href"].Value;

            //    var ratingNode = titleNode.SelectSingleNode("div[@class=\"rating-info\"]");
            //    string? rating = ratingNode.SelectSingleNode("span[@class=\"rating_nums\"]")?.InnerText;
            //    string subjects = ratingNode.SelectSingleNode("span[@class=\"subject-cast\"]").InnerText;

            //    string? detail = node.SelectSingleNode("p")?.InnerText;

            //    _bookHtmlContents.Add(new BookHtmlContent() {
            //        Title = title,
            //        Url = url,
            //        Rate = rating,
            //        Subjects = subjects,
            //        Detail = detail,
            //    });
            //}
        }
    }
}
