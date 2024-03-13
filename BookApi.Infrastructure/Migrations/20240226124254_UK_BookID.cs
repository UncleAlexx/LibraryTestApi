using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UK_BookID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stock_BookID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Lending_BookID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.CreateIndex(
                name: "UK_BookID",
                schema: "Books",
                table: "Stock",
                column: "BookID",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "UK_BookID",
                schema: "Books",
                table: "Lending",
                column: "BookID",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_BookID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "UK_BookID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_BookID",
                schema: "Books",
                table: "Stock",
                column: "BookID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lending_BookID",
                schema: "Books",
                table: "Lending",
                column: "BookID",
                unique: true);
        }
    }
}
