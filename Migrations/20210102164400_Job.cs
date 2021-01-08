using Microsoft.EntityFrameworkCore.Migrations;

namespace Pop_Stefana_Proiect.Migrations
{
    public partial class Job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Denumire",
                table: "Departament");

            migrationBuilder.AddColumn<string>(
                name: "NumeDepartament",
                table: "Departament",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Angajat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipJob = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_JobID",
                table: "Angajat",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Angajat_Job_JobID",
                table: "Angajat",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Angajat_Job_JobID",
                table: "Angajat");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Angajat_JobID",
                table: "Angajat");

            migrationBuilder.DropColumn(
                name: "NumeDepartament",
                table: "Departament");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Angajat");

            migrationBuilder.AddColumn<string>(
                name: "Denumire",
                table: "Departament",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
