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
                    Sex = true,
                    Name = "万兆奕"
                },
                new User {
                    Id = "shr",
                    Password = "shr",
                    Sex = true,
                    Name = "宋昊睿"
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
        }
    }
}
