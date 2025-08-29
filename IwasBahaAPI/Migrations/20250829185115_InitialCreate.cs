using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IwasBahaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadStatusUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadStatusUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Barangay = table.Column<string>(type: "TEXT", nullable: false),
                    RoadStatusUpdateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadStatuses_RoadStatusUpdates_RoadStatusUpdateId",
                        column: x => x.RoadStatusUpdateId,
                        principalTable: "RoadStatusUpdates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RoadStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roads_RoadStatuses_RoadStatusId",
                        column: x => x.RoadStatusId,
                        principalTable: "RoadStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roads_RoadStatusId",
                table: "Roads",
                column: "RoadStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadStatuses_RoadStatusUpdateId",
                table: "RoadStatuses",
                column: "RoadStatusUpdateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "RoadStatuses");

            migrationBuilder.DropTable(
                name: "RoadStatusUpdates");
        }
    }
}
