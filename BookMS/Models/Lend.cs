using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMS.Models {
    public class Lend {
        [Key]
        public int No { get; set; }
        public string Uid { get; set; }
        public string Bid { get; set; }
        public DateTime Datetime { get; set; }
    }
}
