using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class one2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Purchases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_AppUserId",
                table: "Purchases",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_AppUserId",
                table: "Purchases",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_AppUserId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_AppUserId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
