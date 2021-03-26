using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Data.Migrations
{
    public partial class addStudent4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "Patronymic", "UniqIdentity" },
                values: new object[] { 4, "Student", 2, "4", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
