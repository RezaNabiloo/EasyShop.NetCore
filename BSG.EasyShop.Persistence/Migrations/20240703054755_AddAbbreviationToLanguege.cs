using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSG.EasyShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAbbreviationToLanguege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Langueges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Langueges",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Abbreviation",
                value: "Fa");

            migrationBuilder.UpdateData(
                table: "Langueges",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Abbreviation",
                value: "En");

            migrationBuilder.UpdateData(
                table: "Langueges",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Abbreviation",
                value: "Ar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Langueges");
        }
    }
}
