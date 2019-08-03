using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class hh10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
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
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hopitals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    PositionGeographique = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    AdminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hopitals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hopitals_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appareils",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    DatePurchase = table.Column<DateTime>(nullable: false),
                    DateFabrication = table.Column<DateTime>(nullable: false),
                    LastDateUse = table.Column<DateTime>(nullable: false),
                    NatureDiseaseTreat = table.Column<string>(nullable: true),
                    prixPurchase = table.Column<double>(nullable: false),
                    FrequencyUsage = table.Column<string>(nullable: true),
                    ConditionUse = table.Column<string>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    HospitalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appareils", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appareils_Hopitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hopitals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "email", "firstName", "lastName", "password", "token" },
                values: new object[] { 1, "boutakatmohamed@gmail.com", "mohamed", "boutakat", "justme", null });

            migrationBuilder.CreateIndex(
                name: "IX_Appareils_HospitalID",
                table: "Appareils",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Hopitals_AdminID",
                table: "Hopitals",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appareils");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hopitals");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
