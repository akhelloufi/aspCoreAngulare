using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class kh_mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Hopitals_HopitalID",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_HopitalID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "HopitalID",
                table: "InvoiceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Appareils_HopitalID",
                table: "Appareils",
                column: "HopitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appareils_Hopitals_HopitalID",
                table: "Appareils",
                column: "HopitalID",
                principalTable: "Hopitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appareils_Hopitals_HopitalID",
                table: "Appareils");

            migrationBuilder.DropIndex(
                name: "IX_Appareils_HopitalID",
                table: "Appareils");

            migrationBuilder.AddColumn<int>(
                name: "HopitalID",
                table: "InvoiceDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_HopitalID",
                table: "InvoiceDetails",
                column: "HopitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Hopitals_HopitalID",
                table: "InvoiceDetails",
                column: "HopitalID",
                principalTable: "Hopitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
