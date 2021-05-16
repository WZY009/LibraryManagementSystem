using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMS.Tests {
    [TestClass()]
    public class SpiderTests {
        [TestMethod()]
        public void GetResponseTest() {
            Spider.GetResponse("高等数学");
            Assert.Fail();
        }
    }
}