using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SusWarriors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDosageWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DosageWeight",
                table: "MedItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosageWeight",
                table: "MedItem");
        }
    }
}
