using BookMS.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BookMS.Controllers {


    public class SpiderController : IDisposable {
        #region 辅助类
        private struct DoubanJson {
            public string[] items;
            public int total;
            public int limit;
            public bool more;
        }

        /// <summary>
        /// 豆瓣上一本书的信息
        /// </summary>
        public struct BookHtmlContent {
            public string Title { get; set; }
            public string Url { get; set; }
            public string? ImageUrl { get; set; }
            public string? Rate { get; set; }
            public string? Subjects { get; set; }
            public string? Detail { get; set; }
        }
        #endregion

        private readonly string _url;
        private int _currentNumber = 0;
        //private List<BookHtmlContent> _bookHtmlContents = new List<BookHtmlContent>();
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// 所要查询的书目
        /// </summary>
        public string BookName { get; private set; }
        /// <summary>
        /// 是否含有更多条目
        /// </summary>
        public bool HasNext { get; private set; } = true;
        /// <summary>
        /// 本页所含有的所有书目信息
        /// </summary>
        //public IEnumerable<BookHtmlContent> BookHtmlContents { get => _bookHtmlContents; }

        /// <summary>
        /// 对于每一本所要查询的书，创建一个Spider类
        /// </summary>
        /// <param name="bookName"></param>
        public SpiderController(string bookName) {
            BookName = bookName;
            bookName = HttpUtility.UrlEncode(bookName);
            _url = $"https://www.douban.com/j/search?q={bookName}&start={{0}}&cat=1001"; // 两个大括号表示字符串包含大括号
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0");
        }

        private async Task<string> GetResponseAsync(string url) {
            HttpResponseMessage response = await _client.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : throw new Exception($"请求http未成功，网页返回代码{response.StatusCode}");
        }

        /// <summary>
        /// 读取下一页
        /// </summary>
        /// <returns>一个包含本页所有书目信息的迭代器</returns>
        public async Task<IEnumerable<BookHtmlContent>> ReadNextAsync() {
            if (!HasNext) 
                throw new Exception("End");//已经读到头了
            string result = await GetResponseAsync(string.Format(_url, _currentNumber));
            DoubanJson doubanJson = JsonConvert.DeserializeObject<DoubanJson>(result);
            HasNext = doubanJson.more;  // 是否到头
            _currentNumber += doubanJson.limit; // 下一次搜索位置

            // 获取所有查询到的书目进行Html解码
            List<string> items = new List<string>();
            foreach (string item in doubanJson.items)
                items.Add(HttpUtility.HtmlDecode(item));
            List<BookHtmlContent> bookHtmlContents = new List<BookHtmlContent>();
            // 获取本页的所有书目
            foreach (string item in items) {
                HtmlDocument itemDocument = new HtmlDocument();
                itemDocument.LoadHtml(item);
                var itemNode = itemDocument.DocumentNode.SelectSingleNode("//div[@class=\"result\"]/div[@class=\"content\"]");
                //if (itemNode == null) throw new Exception("未查询到关键词所对应的书");

                string? imageUrl = itemNode.SelectSingleNode("div[@class=\"pic\"]/a[@class=\"nbg\"]/img")?.Attributes["src"].Value;

                var titleNode = itemNode.SelectSingleNode("div[@class=\"title\"]");
                string title = titleNode.SelectSingleNode("h3/a").InnerText;
                string url = titleNode.SelectSingleNode("h3/a").Attributes["href"].Value;

                var ratingNode = titleNode.SelectSingleNode("div[@class=\"rating-info\"]");
                string? rating = ratingNode.SelectSingleNode("span[@class=\"rating_nums\"]")?.InnerText;
                string? subjects = ratingNode.SelectSingleNode("span[@class=\"subject-cast\"]")?.InnerText;

                string? detail = itemNode.SelectSingleNode("p")?.InnerText;

                bookHtmlContents.Add(new BookHtmlContent() {
                    Title = title,
                    Url = url,
                    ImageUrl = imageUrl,
                    Rate = rating,
                    Subjects = subjects,
                    Detail = detail,
                });
            }
            return bookHtmlContents;
        }

        public void Dispose() => _client.Dispose();
    }
}
