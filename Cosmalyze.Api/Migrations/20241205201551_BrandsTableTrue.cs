using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cosmalyze.Api.Migrations
{
    /// <inheritdoc />
    public partial class BrandsTableTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update IsCrueltyFree to true for brands with Id from 923 to 983
            for (int id = 923; id <= 983; id++)
            {
                migrationBuilder.UpdateData(
                    table: "Brands",
                    keyColumn: "Id",
                    keyValue: id,
                    column: "IsCrueltyFree",
                    value: true);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert IsCrueltyFree to false for brands with Id from 923 to 983
            for (int id = 923; id <= 983; id++)
            {
                migrationBuilder.UpdateData(
                    table: "Brands",
                    keyColumn: "Id",
                    keyValue: id,
                    column: "IsCrueltyFree",
                    value: false);
            }
        }
    }
}
