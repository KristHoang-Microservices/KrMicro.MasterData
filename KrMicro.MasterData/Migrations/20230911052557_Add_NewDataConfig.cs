using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    public partial class Add_NewDataConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products");

            migrationBuilder.AlterColumn<short>(
                name: "release_year",
                table: "Products",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "brand_id",
                table: "Products",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "BrandId",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.AlterColumn<short>(
                name: "release_year",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "brand_id",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
