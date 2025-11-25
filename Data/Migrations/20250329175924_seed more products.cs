using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainsHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedmoreproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { 2, null, "120g, Orange | NABL Lab Tested | 3g Creatine/Serving | Increases Muscle Mass, Strength & Power | Pre & Post Workout Supplement | For Men & Women", "https://m.media-amazon.com/images/I/712pPYduEPL._SL1500_.jpg", "Nutrabay Gold Micronised Creatine Monohydrate Powder", 379.99m, 9 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
