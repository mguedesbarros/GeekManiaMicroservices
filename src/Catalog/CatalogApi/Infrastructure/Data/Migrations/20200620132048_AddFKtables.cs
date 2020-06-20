using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogApi.Infrastructure.Data.Migrations
{
    public partial class AddFKtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_category_id",
                table: "Product");
        }
    }
}
