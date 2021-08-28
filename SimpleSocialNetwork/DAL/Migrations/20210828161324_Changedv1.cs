using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Changedv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
