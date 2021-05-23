using NUnit.Framework;
using BookMS;
using BookMS.Controllers;

namespace TestProject1 {
    public class Tests {
        SpiderController spider;

        [SetUp]
        public void Setup() {
            spider = new SpiderController("高等数学");
        }

        [Test]
        public void Test1() {
            Assert.DoesNotThrowAsync(async () => await spider.ReadNextAsync());
            Assert.AreEqual(spider.HasNext, true);
        }
    }
}