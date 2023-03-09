using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inter_Assignment.Data.Migrations
{
    public partial class TaskUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TaskId",
                table: "Employees",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Tasks_TaskId",
                table: "Employees",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Tasks_TaskId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TaskId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Employees");
        }
    }
}
