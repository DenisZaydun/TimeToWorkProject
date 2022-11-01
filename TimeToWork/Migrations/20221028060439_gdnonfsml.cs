using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeToWork.Migrations
{
    public partial class gdnonfsml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceServiceProvider_Service_ServisesServiceId",
                table: "ServiceServiceProvider");

            migrationBuilder.RenameColumn(
                name: "ServisesServiceId",
                table: "ServiceServiceProvider",
                newName: "ServicesServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceServiceProvider_ServisesServiceId",
                table: "ServiceServiceProvider",
                newName: "IX_ServiceServiceProvider_ServicesServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceServiceProvider_Service_ServicesServiceId",
                table: "ServiceServiceProvider",
                column: "ServicesServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceServiceProvider_Service_ServicesServiceId",
                table: "ServiceServiceProvider");

            migrationBuilder.RenameColumn(
                name: "ServicesServiceId",
                table: "ServiceServiceProvider",
                newName: "ServisesServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceServiceProvider_ServicesServiceId",
                table: "ServiceServiceProvider",
                newName: "IX_ServiceServiceProvider_ServisesServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceServiceProvider_Service_ServisesServiceId",
                table: "ServiceServiceProvider",
                column: "ServisesServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
