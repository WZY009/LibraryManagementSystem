using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    public class Admin {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhotoPath { get; set; }
    }
}
