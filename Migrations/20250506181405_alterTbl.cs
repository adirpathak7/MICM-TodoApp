using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class alterTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "storageType",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "todoTitle",
                table: "Todos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "todoId",
                table: "Todos",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Todos",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todos",
                newName: "todoTitle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todos",
                newName: "todoId");

            migrationBuilder.AddColumn<string>(
                name: "storageType",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
