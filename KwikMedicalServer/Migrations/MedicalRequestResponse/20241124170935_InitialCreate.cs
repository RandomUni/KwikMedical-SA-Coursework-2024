using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikMedicalServer.Migrations.MedicalRequestResponse
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    NHSNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PatientName = table.Column<string>(type: "TEXT", nullable: false),
                    TimeReceived = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HospitalAllocated = table.Column<string>(type: "TEXT", nullable: false),
                    HealthcareProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Actions = table.Column<string>(type: "TEXT", nullable: false),
                    AmbulanceAllocated = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");
        }
    }
}
