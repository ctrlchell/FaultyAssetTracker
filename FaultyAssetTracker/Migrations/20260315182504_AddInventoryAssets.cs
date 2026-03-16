using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FaultyAssetTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssetTag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAssets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InventoryAssets",
                columns: new[] { "Id", "AssetName", "AssetTag", "Branch", "Category", "CreatedAt", "SerialNo", "Vendor" },
                values: new object[,]
                {
                    { 1, "Dell Latitude 5420", "ASSET-LAP-0001", "Head Office", "Laptop", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "DL5420-0001", "Chams Access" },
                    { 2, "Verifone V200c", "ASSET-POS-0012", "Ikeja Branch", "POS Terminal", new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "VF200C-7781", "PFS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAssets_AssetTag",
                table: "InventoryAssets",
                column: "AssetTag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAssets_SerialNo",
                table: "InventoryAssets",
                column: "SerialNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAssets");
        }
    }
}
