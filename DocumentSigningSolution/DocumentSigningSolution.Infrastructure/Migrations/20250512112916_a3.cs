using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentSigningSolution.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_FolderId",
                table: "Documents",
                columns: new[] { "Name", "FolderId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_FolderId",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name",
                table: "Documents",
                column: "Name",
                unique: true);
        }
    }
}
