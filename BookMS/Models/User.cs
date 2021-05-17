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
        [Required]
        public string Name { get; set; }
        public bool Sex { get; set; }
        [Required]
        // 在发行为二进制文件时添加密码的最小长度限制，在数据库迁移时反注释下一行
        //[MinLength(6)]
        [MaxLength(30)]
        public string Password { get; set; }
        public string PhotoPath { get; set; }
        public string Major { get; set; }
        [Required]
        public int VerifyQuestion { get; set; }
        [Required]
        public string VerifyAnswer { get; set; }
    }
}
