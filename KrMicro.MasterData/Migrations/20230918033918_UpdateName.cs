using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    public partial class UpdateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Products",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "style_description",
                table: "Products",
                newName: "StyleDescription");

            migrationBuilder.RenameColumn(
                name: "release_year",
                table: "Products",
                newName: "ReleaseYear");

            migrationBuilder.RenameColumn(
                name: "import_from",
                table: "Products",
                newName: "ImportFrom");

            migrationBuilder.RenameColumn(
                name: "image_urls",
                table: "Products",
                newName: "ImageUrls");

            migrationBuilder.RenameColumn(
                name: "fragrance_description",
                table: "Products",
                newName: "FragranceDescription");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_category_id",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_brand_id",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Categories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Categories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Categories",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Brands",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Brands",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Brands",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Brands",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Brands",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Brands",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Brands",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Asc",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Asc",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "hotline",
                table: "Asc",
                newName: "Hotline");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Asc",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Asc",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Asc",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Asc",
                newName: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Products",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Products",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StyleDescription",
                table: "Products",
                newName: "style_description");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Products",
                newName: "release_year");

            migrationBuilder.RenameColumn(
                name: "ImportFrom",
                table: "Products",
                newName: "import_from");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "Products",
                newName: "image_urls");

            migrationBuilder.RenameColumn(
                name: "FragranceDescription",
                table: "Products",
                newName: "fragrance_description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                newName: "IX_Products_brand_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Categories",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Categories",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Categories",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Brands",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Brands",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Brands",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Brands",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Brands",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Asc",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Asc",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Hotline",
                table: "Asc",
                newName: "hotline");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Asc",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Asc",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Asc",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Asc",
                newName: "created_at");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id");
        }
    }
}
