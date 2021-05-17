using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMS.Models {
    class AppDbContent : DbContext {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VerifyQuestion> VerifyQuesions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(@"server=localhost;database=BookDB;uid=root;pwd=root;CharSet=utf8");
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Admin>().HasData(
                new Admin {
                    Id = "admin",
                    Password = "admin"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = "wzy",
                    Password = "wzy",
                    Sex = User.MALE,
                    Name = "万兆奕",
                    Major = "计算机科学与技术",
                    Question_id = 1,
                    Question_answer = "野兽仙贝",
                },
                new User {
                    Id = "shr",
                    Password = "shr",
                    Sex = User.MALE,
                    Name = "宋昊睿",
                    Major = "计科",
                    Question_id = 3,
                    Question_answer = "红色",
                },
                new User {
                    Id = "murasame",
                    Password = "goshujin",
                    Sex = User.FEMALE,
                    Name = "丛雨",
                    Major = "冷兵器护理",
                    Question_id = 2,
                    Question_answer = "有地将臣",
                }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book {
                    Id = "978-7-302-34695-1",
                    Name = "数据库原理与技术",
                    Author = "尹为民",
                    Press = "清华大学出版社",
                    Number = 20,
                },
                new Book {
                    Id = "978-7-111-50482-5",
                    Name = "计算机组成与设计",
                    Author = "David A. Patterson",
                    Press = "机械工业出版社",
                    Number = 10,
                }
                );
            modelBuilder.Entity<VerifyQuestion>().HasData(
                new VerifyQuestion {
                    ID = 1,
                    Question = "你最喜欢的食物是什么？",
                },
                new VerifyQuestion {
                    ID = 2,
                    Question = "你的第一任老师是谁？",
                },
                new VerifyQuestion {
                    ID = 3,
                    Question = "你最喜欢的颜色是什么？",
                },
                new VerifyQuestion {
                    ID = 4,
                    Question = "你养的第一个宠物名字叫什么？",
                },
                new VerifyQuestion {
                    ID = 5,
                    Question = "你的第一个同桌是谁？",
                }
                );
        }
    }
}
