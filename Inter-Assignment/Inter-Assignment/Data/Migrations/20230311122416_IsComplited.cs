using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inter_Assignment.Data.Migrations
{
    public partial class IsComplited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsCompleted",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsCompleted",
                value: false);
        }
    }
}
