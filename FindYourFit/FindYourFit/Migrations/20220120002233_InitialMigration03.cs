using Microsoft.EntityFrameworkCore.Migrations;

namespace FindYourFit.Migrations
{
    public partial class InitialMigration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessResource_FitnessResourceCategories_CategoryId",
                table: "FitnessResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessResource",
                table: "FitnessResource");

            migrationBuilder.RenameTable(
                name: "FitnessResource",
                newName: "FitnessResources");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessResource_CategoryId",
                table: "FitnessResources",
                newName: "IX_FitnessResources_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessResources",
                table: "FitnessResources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessResources_FitnessResourceCategories_CategoryId",
                table: "FitnessResources",
                column: "CategoryId",
                principalTable: "FitnessResourceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessResources_FitnessResourceCategories_CategoryId",
                table: "FitnessResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessResources",
                table: "FitnessResources");

            migrationBuilder.RenameTable(
                name: "FitnessResources",
                newName: "FitnessResource");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessResources_CategoryId",
                table: "FitnessResource",
                newName: "IX_FitnessResource_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessResource",
                table: "FitnessResource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessResource_FitnessResourceCategories_CategoryId",
                table: "FitnessResource",
                column: "CategoryId",
                principalTable: "FitnessResourceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
