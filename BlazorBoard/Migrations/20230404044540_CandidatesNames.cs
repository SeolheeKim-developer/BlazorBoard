using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBoard.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_candidatesNames",
                table: "candidatesNames");

            migrationBuilder.RenameTable(
                name: "candidatesNames",
                newName: "CandidatesNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatesNames",
                table: "CandidatesNames",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatesNames",
                table: "CandidatesNames");

            migrationBuilder.RenameTable(
                name: "CandidatesNames",
                newName: "candidatesNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidatesNames",
                table: "candidatesNames",
                column: "Id");
        }
    }
}
