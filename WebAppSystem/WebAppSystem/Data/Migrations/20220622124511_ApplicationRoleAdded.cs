using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppSystem.Data.Migrations
{
    public partial class ApplicationRoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_RecepientId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "RecepientId",
                table: "Transactions",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_RecepientId",
                table: "Transactions",
                newName: "IX_Transactions_RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_RecipientId",
                table: "Transactions",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_RecipientId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Transactions",
                newName: "RecepientId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_RecipientId",
                table: "Transactions",
                newName: "IX_Transactions_RecepientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_RecepientId",
                table: "Transactions",
                column: "RecepientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
