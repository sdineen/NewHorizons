using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CostPrice = table.Column<double>(type: "REAL", nullable: false),
                    RetailPrice = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { "acc1", "John Smith", "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08" },
                    { "acc2", "Jane Jones", "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[,]
                {
                    { 1, 0.69999999999999996, "Pedigree Chum", 1.4199999999999999 },
                    { 2, 0.59999999999999998, "Knife", 1.3100000000000001 },
                    { 3, 0.75, "Fork", 1.5700000000000001 },
                    { 4, 0.90000000000000002, "Spaghetti", 1.9199999999999999 },
                    { 5, 0.65000000000000002, "Cheddar Cheese", 1.47 },
                    { 6, 15.199999999999999, "Bean bag", 32.200000000000003 },
                    { 7, 22.300000000000001, "Bookcase", 46.32 },
                    { 8, 55.200000000000003, "Table", 134.80000000000001 },
                    { 9, 43.700000000000003, "Chair", 110.2 },
                    { 10, 3.2000000000000002, "Doormat", 7.4000000000000004 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
