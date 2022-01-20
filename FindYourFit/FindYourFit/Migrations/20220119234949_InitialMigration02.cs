using Microsoft.EntityFrameworkCore.Migrations;

namespace FindYourFit.Migrations
{
    public partial class InitialMigration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "FitnessResource");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "FitnessResource",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "FitnessResource");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FitnessResource",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
