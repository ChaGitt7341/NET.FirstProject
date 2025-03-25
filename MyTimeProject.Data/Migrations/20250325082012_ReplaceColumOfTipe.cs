using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTimeProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceColumOfTipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presences_Approvals_ApprovalId",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Approvals");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalId",
                table: "Presences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Presences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Presences_Approvals_ApprovalId",
                table: "Presences",
                column: "ApprovalId",
                principalTable: "Approvals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presences_Approvals_ApprovalId",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Presences");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalId",
                table: "Presences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Presences_Approvals_ApprovalId",
                table: "Presences",
                column: "ApprovalId",
                principalTable: "Approvals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
