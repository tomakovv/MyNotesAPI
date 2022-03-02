using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreateNoteDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteDetails_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteDetails_NoteId",
                table: "NoteDetails",
                column: "NoteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteDetails");
        }
    }
}
