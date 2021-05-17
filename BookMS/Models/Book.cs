using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMS.Models {
    public class Book {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Press { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
