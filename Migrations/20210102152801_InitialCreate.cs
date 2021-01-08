﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pop_Stefana_Proiect.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumePrenume = table.Column<string>(nullable: true),
                    DataAngajarii = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NrTelefon = table.Column<int>(nullable: false),
                    Salariu = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
