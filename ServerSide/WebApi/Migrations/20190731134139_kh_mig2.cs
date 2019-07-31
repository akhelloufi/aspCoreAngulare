using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class kh_mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrateur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cin = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateur", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hopitals_AdminID",
                table: "Hopitals",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hopitals_Administrateur_AdminID",
                table: "Hopitals",
                column: "AdminID",
                principalTable: "Administrateur",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hopitals_Administrateur_AdminID",
                table: "Hopitals");

            migrationBuilder.DropTable(
                name: "Administrateur");

            migrationBuilder.DropIndex(
                name: "IX_Hopitals_AdminID",
                table: "Hopitals");
        }
    }
}
