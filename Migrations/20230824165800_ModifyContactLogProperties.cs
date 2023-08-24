using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContactLogProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactLogs_Contacts_ContactId",
                table: "ContactLogs");

            migrationBuilder.DropIndex(
                name: "IX_ContactLogs_ContactId",
                table: "ContactLogs");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ContactLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
