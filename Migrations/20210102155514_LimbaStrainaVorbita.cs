using Microsoft.EntityFrameworkCore.Migrations;

namespace Pop_Stefana_Proiect.Migrations
{
    public partial class LimbaStrainaVorbita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentID",
                table: "Angajat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LimbaStraina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumirea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimbaStraina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LimbaStrainaVorbita",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatID = table.Column<int>(nullable: false),
                    LimbaStrainaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimbaStrainaVorbita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LimbaStrainaVorbita_Angajat_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Angajat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LimbaStrainaVorbita_LimbaStraina_LimbaStrainaID",
                        column: x => x.LimbaStrainaID,
                        principalTable: "LimbaStraina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_DepartamentID",
                table: "Angajat",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_LimbaStrainaVorbita_AngajatID",
                table: "LimbaStrainaVorbita",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_LimbaStrainaVorbita_LimbaStrainaID",
                table: "LimbaStrainaVorbita",
                column: "LimbaStrainaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Angajat_Departament_DepartamentID",
                table: "Angajat",
                column: "DepartamentID",
                principalTable: "Departament",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Angajat_Departament_DepartamentID",
                table: "Angajat");

            migrationBuilder.DropTable(
                name: "Departament");

            migrationBuilder.DropTable(
                name: "LimbaStrainaVorbita");

            migrationBuilder.DropTable(
                name: "LimbaStraina");

            migrationBuilder.DropIndex(
                name: "IX_Angajat_DepartamentID",
                table: "Angajat");

            migrationBuilder.DropColumn(
                name: "DepartamentID",
                table: "Angajat");
        }
    }
}
