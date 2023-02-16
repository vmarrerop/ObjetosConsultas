using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelosConsultas.Migrations
{
    /// <inheritdoc />
    public partial class CreateConsulttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antropometricos",
                columns: table => new
                {
                    idPatientAnthropometricData = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    height = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antropometricos", x => x.idPatientAnthropometricData);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idPatienteFile = table.Column<int>(type: "int", nullable: false),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.idEvent);
                });

            migrationBuilder.CreateTable(
                name: "Habito",
                columns: table => new
                {
                    idPatientBowelHabit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habito", x => x.idPatientBowelHabit);
                });

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    idPatientReasonOfVisit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.idPatientReasonOfVisit);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    idPatientCheckupNote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.idPatientCheckupNote);
                });

            migrationBuilder.CreateTable(
                name: "Padecimiento",
                columns: table => new
                {
                    idPatientSuffering = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suffering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUserModifiedBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padecimiento", x => x.idPatientSuffering);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antropometricos");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Habito");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Padecimiento");
        }
    }
}
