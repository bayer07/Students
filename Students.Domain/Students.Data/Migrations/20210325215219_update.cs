using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GroupStudents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Developers" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "Patronymic", "UniqIdentity" },
                values: new object[] { 1, "Bair", 0, "Dongak", "Orlanovich", "bayer07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GroupStudents");
        }
    }
}
