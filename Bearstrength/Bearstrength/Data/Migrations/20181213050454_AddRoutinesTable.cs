using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bearstrength.Migrations
{
    public partial class AddRoutinesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    Repetitions = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Rest = table.Column<TimeSpan>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routines_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routines_ActivityId",
                table: "Routines",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routines");
        }
    }
}
