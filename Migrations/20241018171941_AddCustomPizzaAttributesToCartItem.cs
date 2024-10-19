using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaritoShop.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomPizzaAttributesToCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Chicken",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pepperoni",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StuffedCrust",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ThinCrispy",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chicken",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Pepperoni",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "StuffedCrust",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ThinCrispy",
                table: "CartItems");
        }
    }
}
