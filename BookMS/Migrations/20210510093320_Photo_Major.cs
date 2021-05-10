using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMS.Migrations
{
    public partial class Photo_Major : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Admins",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "shr",
                column: "Major",
                value: "计科");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "wzy",
                column: "Major",
                value: "计算机科学与技术");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Major", "Name", "Password", "PhotoPath", "Sex" },
                values: new object[] { "murasame", "冷兵器护理", "丛雨", "goshujin", null, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "murasame");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Admins");
        }
    }
}
