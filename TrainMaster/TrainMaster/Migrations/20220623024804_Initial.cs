using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainMaster.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    TrainNo = table.Column<int>(type: "int", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JourneyStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    JourneyEndTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.TrainNo);
                });

            migrationBuilder.CreateTable(
                name: "TrainSchedules",
                columns: table => new
                {
                    TrainNo = table.Column<int>(type: "int", nullable: false),
                    TrainRunDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainNo1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainSchedules", x => x.TrainNo);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_Trains_TrainNo1",
                        column: x => x.TrainNo1,
                        principalTable: "Trains",
                        principalColumn: "TrainNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_TrainNo1",
                table: "TrainSchedules",
                column: "TrainNo1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainSchedules");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
