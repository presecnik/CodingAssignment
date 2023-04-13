using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingAssignment.Migrations
{
    /// <inheritdoc />
    public partial class Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    assigned_user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id);
                    table.ForeignKey(
                        name: "FK_Task_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_project_id",
                table: "Task",
                column: "project_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
