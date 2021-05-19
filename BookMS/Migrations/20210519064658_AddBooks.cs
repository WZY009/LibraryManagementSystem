using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BookMS.Migrations
{
    public partial class AddBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: true),
                    Press = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerifyQuesions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyQuesions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Major = table.Column<string>(type: "text", nullable: true),
                    Question_id = table.Column<int>(type: "int", nullable: false),
                    Question_answer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_VerifyQuesions_Question_id",
                        column: x => x.Question_id,
                        principalTable: "VerifyQuesions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lends",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<string>(type: "varchar(767)", nullable: false),
                    Bid = table.Column<string>(type: "varchar(767)", nullable: false),
                    LendTime = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lends", x => x.No);
                    table.ForeignKey(
                        name: "FK_Lends_Books_Bid",
                        column: x => x.Bid,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lends_Users_Uid",
                        column: x => x.Uid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Number", "Press" },
                values: new object[,]
                {
                    { "978-7-302-34695-1", "尹为民", "数据库原理与技术", 20, "清华大学出版社" },
                    { "978-7-111-50482-5", "David A. Patterson", "计算机组成与设计", 10, "机械工业出版社" },
                    { "114514", "野兽先辈", "真夏夜之淫梦", 30, "真夏夜之淫梦出版社" },
                    { "114514514", "目力先辈", "恶臭的传说", 100, null },
                    { "70-123456", "HARUKAZE", "野良与皇女与流浪猫之心", 3, "不是柚子社" },
                    { "96123", "柚子社", "千恋万花", 12, "hikari field" }
                });

            migrationBuilder.InsertData(
                table: "VerifyQuesions",
                columns: new[] { "ID", "Question" },
                values: new object[,]
                {
                    { 1, "你最喜欢的食物是什么？" },
                    { 2, "你的第一任老师是谁？" },
                    { 3, "你最喜欢的颜色是什么？" },
                    { 4, "你养的第一个宠物名字叫什么？" },
                    { 5, "你的第一个同桌是谁？" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Major", "Name", "Password", "PhotoPath", "Question_answer", "Question_id", "Sex" },
                values: new object[] { "wzy", "计算机科学与技术", "万兆奕", "wzy", null, "野兽仙贝", 1, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Major", "Name", "Password", "PhotoPath", "Question_answer", "Question_id", "Sex" },
                values: new object[] { "murasame", "冷兵器护理", "丛雨", "goshujin", null, "有地将臣", 2, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Major", "Name", "Password", "PhotoPath", "Question_answer", "Question_id", "Sex" },
                values: new object[] { "shr", "计科", "宋昊睿", "shr", null, "红色", 3, true });

            migrationBuilder.CreateIndex(
                name: "IX_Lends_Bid",
                table: "Lends",
                column: "Bid");

            migrationBuilder.CreateIndex(
                name: "IX_Lends_Uid",
                table: "Lends",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Question_id",
                table: "Users",
                column: "Question_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Lends");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VerifyQuesions");
        }
    }
}
