using Microsoft.EntityFrameworkCore.Migrations;

namespace Conan.Data.Migrations
{
    public partial class AlterMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Messages",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "Messages",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                newName: "IX_Messages_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AppUserId",
                table: "Messages",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserId",
                table: "Messages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AppUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "Messages",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Messages",
                newName: "ReceiverID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages",
                newName: "IX_Messages_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                newName: "IX_Messages_ReceiverID");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Messages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
