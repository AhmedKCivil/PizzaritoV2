using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaritoShop.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameOfPizzaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzasmodel",
                table: "Pizzasmodel");

            migrationBuilder.RenameTable(
                name: "Pizzasmodel",
                newName: "Pizzas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Pizzasmodel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzasmodel",
                table: "Pizzasmodel",
                column: "Id");
        }
    }
}
