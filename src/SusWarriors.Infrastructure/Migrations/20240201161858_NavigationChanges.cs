using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SusWarriors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NavigationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MedItemWithCategory_MedItemCategoryId",
                table: "MedItemWithCategory",
                column: "MedItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedItemWithCategory_MedItemId",
                table: "MedItemWithCategory",
                column: "MedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedItemWithCategory_MedItemCategory_MedItemCategoryId",
                table: "MedItemWithCategory",
                column: "MedItemCategoryId",
                principalTable: "MedItemCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedItemWithCategory_MedItem_MedItemId",
                table: "MedItemWithCategory",
                column: "MedItemId",
                principalTable: "MedItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedItemWithCategory_MedItemCategory_MedItemCategoryId",
                table: "MedItemWithCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedItemWithCategory_MedItem_MedItemId",
                table: "MedItemWithCategory");

            migrationBuilder.DropIndex(
                name: "IX_MedItemWithCategory_MedItemCategoryId",
                table: "MedItemWithCategory");

            migrationBuilder.DropIndex(
                name: "IX_MedItemWithCategory_MedItemId",
                table: "MedItemWithCategory");
        }
    }
}
