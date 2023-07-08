using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowedMaxPassagerCount = table.Column<int>(type: "int", nullable: false),
                    CurrentPassangerCount = table.Column<int>(type: "int", nullable: false),
                    isThisTripActive = table.Column<bool>(type: "bit", nullable: false),
                    Routate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    PassengerCountForThisDistance = table.Column<int>(type: "int", nullable: false),
                    TripFK = table.Column<int>(type: "int", nullable: false),
                    TripDetailToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetail_Trip_TripFK",
                        column: x => x.TripFK,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passanger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassangerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripDetailFk = table.Column<int>(type: "int", nullable: false),
                    TokenForThisReservation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passanger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passanger_TripDetail_TripDetailFk",
                        column: x => x.TripDetailFk,
                        principalTable: "TripDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passanger_TripDetailFk",
                table: "Passanger",
                column: "TripDetailFk");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripFK",
                table: "TripDetail",
                column: "TripFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passanger");

            migrationBuilder.DropTable(
                name: "TripDetail");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
