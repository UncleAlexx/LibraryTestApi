using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lending",
                schema: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LendingDate = table.Column<DateTime>(type: "datetime2(2)", precision: 2, scale: 2, nullable: false),
                    Return = table.Column<DateTime>(type: "datetime2(2)", precision: 2, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lending_Book_ID",
                        column: x => x.ID,
                        principalSchema: "Books",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isbn = table.Column<string>(type: "char(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stock_Book_ID",
                        column: x => x.ID,
                        principalSchema: "Books",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UK_Isbn",
                schema: "Books",
                table: "Stock",
                column: "Isbn",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lending",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "Stock",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "Books");
        }
    }
}
