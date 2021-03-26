using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Data.Migrations
{
    public partial class FixDbInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 1);
        }
    }
}
