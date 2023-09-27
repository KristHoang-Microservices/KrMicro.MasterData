using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    public partial class AddDeliveryReconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryOptions");

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "DeliveryVendors",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "DeliveryVendors");

            migrationBuilder.CreateTable(
                name: "DeliveryOptions",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FK_Deliver_Options = table.Column<short>(type: "smallint", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOptions_DeliveryVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "DeliveryVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOptions_VendorId",
                table: "DeliveryOptions",
                column: "VendorId");
        }
    }
}
