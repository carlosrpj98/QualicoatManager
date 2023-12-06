using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualicoatManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssesmentsGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssesmentsGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulationsFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulationsFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: true),
                    AssessmentsGroupId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assesments_AssesmentsGroup_AssessmentsGroupId",
                        column: x => x.AssessmentsGroupId,
                        principalTable: "AssesmentsGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Formulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssesmentsGroupId = table.Column<int>(type: "int", nullable: true),
                    FormulationsFolderId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulations_AssesmentsGroup_AssesmentsGroupId",
                        column: x => x.AssesmentsGroupId,
                        principalTable: "AssesmentsGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formulations_FormulationsFolders_FormulationsFolderId",
                        column: x => x.FormulationsFolderId,
                        principalTable: "FormulationsFolders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    BaseUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormulationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    FormulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulationItems_Formulations_FormulationId",
                        column: x => x.FormulationId,
                        principalTable: "Formulations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulationItems_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_AssessmentsGroupId",
                table: "Assesments",
                column: "AssessmentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulationItems_FormulationId",
                table: "FormulationItems",
                column: "FormulationId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulationItems_RawMaterialId",
                table: "FormulationItems",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulations_AssesmentsGroupId",
                table: "Formulations",
                column: "AssesmentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulations_FormulationsFolderId",
                table: "Formulations",
                column: "FormulationsFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_BaseUserId",
                table: "UserRole",
                column: "BaseUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "FormulationItems");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Formulations");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AssesmentsGroup");

            migrationBuilder.DropTable(
                name: "FormulationsFolders");
        }
    }
}
