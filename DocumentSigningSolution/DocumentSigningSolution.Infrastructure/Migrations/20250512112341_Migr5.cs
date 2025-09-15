using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentSigningSolution.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migr5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name",
                table: "Documents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name",
                table: "Documents",
                column: "Name",
                unique: true);
        }
    }
}
