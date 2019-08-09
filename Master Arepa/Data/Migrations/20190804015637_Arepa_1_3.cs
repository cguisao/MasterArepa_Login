using Microsoft.EntityFrameworkCore.Migrations;

namespace Master_Arepa.Data.Migrations
{
    public partial class Arepa_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "HomeInventory",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "HomeInventory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
