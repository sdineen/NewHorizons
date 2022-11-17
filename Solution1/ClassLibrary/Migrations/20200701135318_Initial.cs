using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CostPrice = table.Column<double>(nullable: false),
                    RetailPrice = table.Column<double>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    AccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { "acc1", "John Smith", "AA95E9BD10D4074140899E90E041A1DBFA05D769632EA01CF9216AABD1B57DE6" },
                    { "acc2", "Jane Jones", "AA95E9BD10D4074140899E90E041A1DBFA05D769632EA01CF9216AABD1B57DE6" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p1", 0.69999999999999996, "Pedigree Chum", 1.4199999999999999 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p2", 0.59999999999999998, "Knife", 1.3100000000000001 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p3", 0.75, "Fork", 1.5700000000000001 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p4", 0.90000000000000002, "Spaghetti", 1.9199999999999999 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p5", 0.65000000000000002, "Cheddar Cheese", 1.47 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p6", 15.199999999999999, "Bean bag", 32.200000000000003 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p7", 22.300000000000001, "Bookcase", 46.32 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p8", 55.200000000000003, "Table", 134.80000000000001 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p9", 43.700000000000003, "Chair", 110.2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "RetailPrice" },
                values: new object[] { "p10", 3.2000000000000002, "Doormat", 7.4000000000000004 });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrderId",
                table: "LineItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
