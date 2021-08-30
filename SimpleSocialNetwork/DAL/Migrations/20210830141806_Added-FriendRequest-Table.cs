using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedFriendRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_FriendId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_UserId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "indx",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FriendRequests",
                newName: "RequestToId");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "FriendRequests",
                newName: "RequestById");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_RequestToId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_FriendId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_RequestById");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_RequestById",
                table: "FriendRequests",
                column: "RequestById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_RequestToId",
                table: "FriendRequests",
                column: "RequestToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_RequestById",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_RequestToId",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "RequestToId",
                table: "FriendRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RequestById",
                table: "FriendRequests",
                newName: "FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_RequestToId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_RequestById",
                table: "FriendRequests",
                newName: "IX_FriendRequests_FriendId");

            migrationBuilder.AddColumn<int>(
                name: "indx",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_FriendId",
                table: "FriendRequests",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_UserId",
                table: "FriendRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
