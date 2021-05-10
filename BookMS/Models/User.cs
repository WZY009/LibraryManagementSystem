using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    public class User {
        public const bool MALE = true;
        public const bool FEMALE = false;

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Password { get; set; }
        public string PhotoPath { get; set; }
        public string Major { get; set; }
    }
}
