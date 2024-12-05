using Microsoft.EntityFrameworkCore.Migrations;

namespace Cosmalyze.Api.Migrations
{
    public partial class DbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add BrandId column to Products table
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            // Insert unique brands from Products table into Brands table
            migrationBuilder.Sql(@"
                INSERT INTO Brands (Name, IsAllVegan, IsPartialVegan, IsCruelty)
                SELECT DISTINCT Brand, 0, 0, 0
                FROM Products
                WHERE Brand IS NOT NULL
            ");

            // Update Products table to set BrandId based on the newly inserted Brands
            migrationBuilder.Sql(@"
                UPDATE Products
                SET BrandId = (SELECT Id FROM Brands WHERE Brands.Name = Products.Brand)
                WHERE Brand IS NOT NULL
            ");

            // Add foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            // Remove the seeded data if rolling back the migration
            migrationBuilder.Sql("DELETE FROM Products WHERE BrandId IS NOT NULL");
            migrationBuilder.Sql("DELETE FROM Brands WHERE Id IN (SELECT DISTINCT BrandId FROM Products)");

            // Drop BrandId column from Products table
            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");
        }
    }
}
