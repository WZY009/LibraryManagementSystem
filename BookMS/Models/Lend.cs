using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMS.Models {
    public class Lend {
        [Key]
        public int No { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Uid { get; set; }
        [Required]
        [ForeignKey("Book")]
        public string Bid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LendTime { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
