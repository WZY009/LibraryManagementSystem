using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    class Admin {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
