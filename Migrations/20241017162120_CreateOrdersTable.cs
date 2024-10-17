using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaritoShop.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdersTable",
                columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            CustomerName = table.Column<string>(nullable: true),
            Address = table.Column<string>(nullable: true),
            PizzaName = table.Column<string>(nullable: true),
            PizzaPrice = table.Column<double>(nullable: true),
            Quantity = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            TotalPrice = table.Column<double>(nullable: false),
            SerializedCartItems = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_OrdersTable", x => x.Id);
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
