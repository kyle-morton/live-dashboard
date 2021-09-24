using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveDashboard.Core.Data.Migrations
{
    public partial class addingshipmentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceStatusId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceStatusId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Shipments");
        }
    }
}
