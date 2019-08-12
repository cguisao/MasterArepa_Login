using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master_Arepa.Data.Migrations
{
    public partial class Arepa_1_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodTruckInventory");

            migrationBuilder.DropTable(
                name: "HomeInventory");

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.CreateTable(
                name: "FoodTruckInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruckInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeInventory", x => x.Id);
                });
        }
    }
}
