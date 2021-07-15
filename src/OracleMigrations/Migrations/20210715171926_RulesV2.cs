using Microsoft.EntityFrameworkCore.Migrations;

namespace OracleMigrations.Migrations
{
    public partial class RulesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Shared = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RequireAllConditions = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    ActionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DirectObject = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RuleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Condition = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Operator = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OnThis = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RuleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_RuleId",
                table: "Actions",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_RuleId",
                table: "Conditions",
                column: "RuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Rules");
        }
    }
}
