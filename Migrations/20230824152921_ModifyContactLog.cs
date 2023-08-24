using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContactLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactLogs_UserLogs_UserLogId",
                table: "ContactLogs");

            migrationBuilder.RenameColumn(
                name: "UserLogId",
                table: "ContactLogs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactLogs_UserLogId",
                table: "ContactLogs",
                newName: "IX_ContactLogs_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "ContactLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactLogs_ContactId",
                table: "ContactLogs",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactLogs_Contacts_ContactId",
                table: "ContactLogs",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactLogs_Users_UserId",
                table: "ContactLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactLogs_Contacts_ContactId",
                table: "ContactLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactLogs_Users_UserId",
                table: "ContactLogs");

            migrationBuilder.DropIndex(
                name: "IX_ContactLogs_ContactId",
                table: "ContactLogs");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ContactLogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ContactLogs",
                newName: "UserLogId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactLogs_UserId",
                table: "ContactLogs",
                newName: "IX_ContactLogs_UserLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactLogs_UserLogs_UserLogId",
                table: "ContactLogs",
                column: "UserLogId",
                principalTable: "UserLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
