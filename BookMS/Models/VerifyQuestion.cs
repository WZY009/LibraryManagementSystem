using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    public class VerifyQuestion {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Question { get; set; }
    }
}
