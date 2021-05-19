using System;
using System.Collections.Generic;
using System.Text;

namespace BookMS.Models {
    public class UserLend {
        /// <summary>
        /// 借阅的编号
        /// </summary>
        public int LandNo { get; set; }
        /// <summary>
        /// 借阅书的ISBN（ID）
        /// </summary>
        public string BookID { get; set; }
        public string BookName { get; set; }
        public DateTime LendTime { get; set; }
    }
}
