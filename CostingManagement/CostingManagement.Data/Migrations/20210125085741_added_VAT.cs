using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CostingManagement.Data.Migrations
{
    public partial class added_VAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VATId",
                schema: "Costing",
                table: "InvoiceCostings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VATs",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VATs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VATs_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VATs_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCostings_VATId",
                schema: "Costing",
                table: "InvoiceCostings",
                column: "VATId");

            migrationBuilder.CreateIndex(
                name: "IX_VATs_CreatedBy",
                schema: "Lookup",
                table: "VATs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VATs_UpdatedBy",
                schema: "Lookup",
                table: "VATs",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceCostings_VATs_VATId",
                schema: "Costing",
                table: "InvoiceCostings",
                column: "VATId",
                principalSchema: "Lookup",
                principalTable: "VATs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceCostings_VATs_VATId",
                schema: "Costing",
                table: "InvoiceCostings");

            migrationBuilder.DropTable(
                name: "VATs",
                schema: "Lookup");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceCostings_VATId",
                schema: "Costing",
                table: "InvoiceCostings");

            migrationBuilder.DropColumn(
                name: "VATId",
                schema: "Costing",
                table: "InvoiceCostings");
        }
    }
}
