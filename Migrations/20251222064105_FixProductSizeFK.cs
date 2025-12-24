using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_POS.Migrations
{
    /// <inheritdoc />
    public partial class FixProductSizeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_sizes_products_ProductId",
                table: "product_sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_category_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_product_sizes_ProductId",
                table: "product_sizes");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "product_sizes",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "product_sizes",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product_sizes",
                newName: "product_id");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "reviews",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "reviews",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId1",
                table: "products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "product_sizes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "product_id",
                table: "product_sizes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "product_sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "product_reviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_reviews_products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "products",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId1",
                table: "products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_product_sizes_ProductId1",
                table: "product_sizes",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_product_reviews_ProductId1",
                table: "product_reviews",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_product_sizes_products_ProductId1",
                table: "product_sizes",
                column: "ProductId1",
                principalTable: "products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId1",
                table: "products",
                column: "CategoryId1",
                principalTable: "categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_sizes_products_ProductId1",
                table: "product_sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_category_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews");

            migrationBuilder.DropTable(
                name: "product_reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_UserId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_product_sizes_ProductId1",
                table: "product_sizes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "product_sizes");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "product_sizes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "product_sizes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "product_sizes",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "product_sizes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "product_sizes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_product_sizes_ProductId",
                table: "product_sizes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_sizes_products_ProductId",
                table: "product_sizes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
