using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Set27.Infra.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "GoodsName",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "GoodsId",
                table: "orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "GoodsName",
                table: "orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
