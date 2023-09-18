using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    public partial class Add_Image_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "category_id");

            migrationBuilder.AddColumn<string>(
                name: "image_urls",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "image_urls",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products",
                newName: "BrandId");
        }
    }
}
