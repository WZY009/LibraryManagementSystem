using NUnit.Framework;
using BookMS;

namespace TestProject1 {
    public class Tests {
        Spider spider;

        [SetUp]
        public void Setup() {
            spider = new Spider("高等数学");
        }

        [Test]
        public void Test1() {
            Assert.DoesNotThrowAsync(async () => await spider.ReadNextAsync());
            Assert.AreEqual(spider.HasNext, true);
        }
    }
}