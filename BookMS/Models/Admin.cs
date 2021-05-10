using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    public class Admin {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
        // 还没更新的时候注释掉上面这句话
        // public string PhotoPath { get; set; }
    }
}
