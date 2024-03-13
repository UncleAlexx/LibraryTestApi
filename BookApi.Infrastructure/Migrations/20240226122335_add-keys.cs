using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Book_ID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Book_ID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lending",
                schema: "Books",
                table: "Lending");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                schema: "Books",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                schema: "Books",
                newName: "Books",
                newSchema: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Books",
                table: "Books",
                newName: "ID");

            migrationBuilder.AddColumn<Guid>(
                name: "BookID",
                schema: "Books",
                table: "Stock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BookID",
                schema: "Books",
                table: "Lending",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                schema: "Books",
                table: "Stock",
                columns: new[] { "ID", "BookID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lending",
                schema: "Books",
                table: "Lending",
                columns: new[] { "ID", "BookID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Books_BookID",
                schema: "Books",
                table: "Lending",
                column: "BookID",
                principalSchema: "Books",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Books_BookID",
                schema: "Books",
                table: "Stock",
                column: "BookID",
                principalSchema: "Books",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Books_BookID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Books_BookID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_BookID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lending",
                schema: "Books",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_BookID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookID",
                schema: "Books",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "BookID",
                schema: "Books",
                table: "Lending");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "Books",
                newName: "Book",
                newSchema: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Books",
                table: "Book",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                schema: "Books",
                table: "Stock",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lending",
                schema: "Books",
                table: "Lending",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                schema: "Books",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Book_ID",
                schema: "Books",
                table: "Lending",
                column: "ID",
                principalSchema: "Books",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Book_ID",
                schema: "Books",
                table: "Stock",
                column: "ID",
                principalSchema: "Books",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
