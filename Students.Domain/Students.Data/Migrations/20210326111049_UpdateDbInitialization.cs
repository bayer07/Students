using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Data.Migrations
{
    public partial class UpdateDbInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId", "Id" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "RnD" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "QA" });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId", "Id" },
                values: new object[] { 2, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
