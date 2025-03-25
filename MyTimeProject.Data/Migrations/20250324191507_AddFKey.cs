using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTimeProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Presences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presences_UserId1",
                table: "Presences",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Presences_Users_UserId1",
                table: "Presences",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presences_Users_UserId1",
                table: "Presences");

            migrationBuilder.DropIndex(
                name: "IX_Presences_UserId1",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Presences");
        }
    }
}
