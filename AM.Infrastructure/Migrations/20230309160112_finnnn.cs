using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finnnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pasger",
                columns: table => new
                {
                    passportNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    birthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PassengerId = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    emailAdress = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    telNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    FullName_FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasger", x => x.passportNumber);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    planeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    planeType = table.Column<int>(type: "int", nullable: false),
                    manufactureDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.planeId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    passportNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    employementDate = table.Column<DateTime>(type: "Date", nullable: false),
                    function = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.passportNumber);
                    table.ForeignKey(
                        name: "FK_Staff_Pasger_passportNumber",
                        column: x => x.passportNumber,
                        principalTable: "Pasger",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travller",
                columns: table => new
                {
                    passportNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    healthInfomation = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travller", x => x.passportNumber);
                    table.ForeignKey(
                        name: "FK_Travller_Pasger_passportNumber",
                        column: x => x.passportNumber,
                        principalTable: "Pasger",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyFlight",
                columns: table => new
                {
                    flightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destination = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    departure = table.Column<string>(type: "nchar(100)", maxLength: 100, nullable: false, defaultValue: "TOUNES"),
                    flightDate = table.Column<DateTime>(type: "Date", nullable: false),
                    effectiveArrival = table.Column<DateTime>(type: "Date", nullable: false),
                    estimatedDuration = table.Column<int>(type: "int", nullable: false),
                    PlaneFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFlight", x => x.flightId);
                    table.ForeignKey(
                        name: "FK_MyFlight_Planes_PlaneFk",
                        column: x => x.PlaneFk,
                        principalTable: "Planes",
                        principalColumn: "planeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    passanFK = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    flightFK = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float(2)", precision: 2, scale: 3, nullable: false),
                    Siege = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false),
                    PassengerpassportNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    flightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.passanFK, x.flightFK });
                    table.ForeignKey(
                        name: "FK_Ticket_MyFlight_flightId",
                        column: x => x.flightId,
                        principalTable: "MyFlight",
                        principalColumn: "flightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Pasger_PassengerpassportNumber",
                        column: x => x.PassengerpassportNumber,
                        principalTable: "Pasger",
                        principalColumn: "passportNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyFlight_PlaneFk",
                table: "MyFlight",
                column: "PlaneFk");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_flightId",
                table: "Ticket",
                column: "flightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerpassportNumber",
                table: "Ticket",
                column: "PassengerpassportNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Travller");

            migrationBuilder.DropTable(
                name: "MyFlight");

            migrationBuilder.DropTable(
                name: "Pasger");

            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
