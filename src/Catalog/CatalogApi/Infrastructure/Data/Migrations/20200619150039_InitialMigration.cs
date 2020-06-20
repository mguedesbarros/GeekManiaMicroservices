using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogApi.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    image = table.Column<string>(maxLength: 2000, nullable: false),
                    status = table.Column<string>(maxLength: 1, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 300, nullable: false),
                    unity_price = table.Column<decimal>(nullable: false),
                    quantity_stock = table.Column<int>(nullable: false),
                    image = table.Column<string>(maxLength: 2000, nullable: false),
                    category_id = table.Column<Guid>(nullable: false),
                    subcategory_id = table.Column<Guid>(nullable: true),
                    novelty_id = table.Column<Guid>(nullable: true),
                    status = table.Column<string>(maxLength: 1, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    category_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    image = table.Column<string>(maxLength: 2000, nullable: false),
                    product_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_product_id",
                table: "ProductImage",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_category_id",
                table: "SubCategory",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
