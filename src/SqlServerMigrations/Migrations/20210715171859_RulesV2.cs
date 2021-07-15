using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlServerMigrations.Migrations
{
    public partial class RulesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireAllConditions",
                table: "Rules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shared",
                table: "Rules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Operator",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequireAllConditions",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Shared",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Conditions");
        }
    }
}
