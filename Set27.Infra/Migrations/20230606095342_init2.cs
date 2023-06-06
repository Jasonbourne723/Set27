using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Set27.Infra.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "orders");

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    GoodsId = table.Column<long>(type: "INTEGER", nullable: false),
                    GoodsName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: false),
                    Nums = table.Column<int>(type: "INTEGER", nullable: false),
                    RealAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDel = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "orders",
                type: "TEXT",
                nullable: true);
        }
    }
}
