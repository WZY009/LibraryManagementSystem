using NUnit.Framework;
using BookMS;

namespace TestProject1 {
    public class Tests {
        Spider spider;

        [SetUp]
        public void Setup() {
            spider = new Spider();
        }

        [Test]
        public void Test1() {
            Assert.DoesNotThrowAsync(async () => await spider.ParseHtml("高等数学"));
        }
    }
}