using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SusWarriors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMedItemWithCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedItem_MedItemEmissions_EmissionsId",
                table: "MedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedItem_MedItemRating_RatingId",
                table: "MedItem");

            migrationBuilder.DropIndex(
                name: "IX_MedItem_EmissionsId",
                table: "MedItem");

            migrationBuilder.DropIndex(
                name: "IX_MedItem_RatingId",
                table: "MedItem");

            migrationBuilder.DropColumn(
                name: "MedicineCatId",
                table: "MedItemRating");

            migrationBuilder.DropColumn(
                name: "EmissionsId",
                table: "MedItem");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "MedItem");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "MedItemRating",
                newName: "MedItemWithCategoryId");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "MedItemEmissions",
                newName: "MedItemId");

            migrationBuilder.RenameColumn(
                name: "MedicineCount",
                table: "DoctorScoring",
                newName: "MedItemCount");

            migrationBuilder.CreateIndex(
                name: "IX_MedItemRating_MedItemWithCategoryId",
                table: "MedItemRating",
                column: "MedItemWithCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedItemEmissions_MedItemId",
                table: "MedItemEmissions",
                column: "MedItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedItemEmissions_MedItem_MedItemId",
                table: "MedItemEmissions",
                column: "MedItemId",
                principalTable: "MedItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedItemRating_MedItemWithCategory_MedItemWithCategoryId",
                table: "MedItemRating",
                column: "MedItemWithCategoryId",
                principalTable: "MedItemWithCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedItemEmissions_MedItem_MedItemId",
                table: "MedItemEmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MedItemRating_MedItemWithCategory_MedItemWithCategoryId",
                table: "MedItemRating");

            migrationBuilder.DropIndex(
                name: "IX_MedItemRating_MedItemWithCategoryId",
                table: "MedItemRating");

            migrationBuilder.DropIndex(
                name: "IX_MedItemEmissions_MedItemId",
                table: "MedItemEmissions");

            migrationBuilder.RenameColumn(
                name: "MedItemWithCategoryId",
                table: "MedItemRating",
                newName: "MedicineId");

            migrationBuilder.RenameColumn(
                name: "MedItemId",
                table: "MedItemEmissions",
                newName: "MedicineId");

            migrationBuilder.RenameColumn(
                name: "MedItemCount",
                table: "DoctorScoring",
                newName: "MedicineCount");

            migrationBuilder.AddColumn<decimal>(
                name: "MedicineCatId",
                table: "MedItemRating",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "EmissionsId",
                table: "MedItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "MedItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MedItem_EmissionsId",
                table: "MedItem",
                column: "EmissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedItem_RatingId",
                table: "MedItem",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedItem_MedItemEmissions_EmissionsId",
                table: "MedItem",
                column: "EmissionsId",
                principalTable: "MedItemEmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedItem_MedItemRating_RatingId",
                table: "MedItem",
                column: "RatingId",
                principalTable: "MedItemRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
