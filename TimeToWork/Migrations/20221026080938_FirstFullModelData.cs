using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeToWork.Migrations
{
    public partial class FirstFullModelData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Client_ClientID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ClienttId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Appointments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientID",
                table: "Appointments",
                newName: "IX_Appointments_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Client_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Client_ClientId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appointments",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                newName: "IX_Appointments_ClientID");

            migrationBuilder.AddColumn<int>(
                name: "ClienttId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Client_ClientID",
                table: "Appointments",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
