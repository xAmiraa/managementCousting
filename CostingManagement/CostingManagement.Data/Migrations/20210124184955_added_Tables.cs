using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CostingManagement.Data.Migrations
{
    public partial class added_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Costing");

            migrationBuilder.EnsureSchema(
                name: "Subscription");

            migrationBuilder.CreateTable(
                name: "DiscrepancyStatuses",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscrepancyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageTypes",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingReportStatuses",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingReportStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppliers_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingReports",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueueNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrnReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ReceivingReportStatusId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingReports_ReceivingReportStatuses_ReceivingReportStatusId",
                        column: x => x.ReceivingReportStatusId,
                        principalSchema: "Lookup",
                        principalTable: "ReceivingReportStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingReports_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Costing",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingReports_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingReports_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivingReportId = table.Column<int>(type: "int", nullable: true),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalSchema: "Lookup",
                        principalTable: "InvoiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_ReceivingReports_ReceivingReportId",
                        column: x => x.ReceivingReportId,
                        principalSchema: "Costing",
                        principalTable: "ReceivingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportingDocuments",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivingReportId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportingDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportingDocuments_ReceivingReports_ReceivingReportId",
                        column: x => x.ReceivingReportId,
                        principalSchema: "Costing",
                        principalTable: "ReceivingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportingDocuments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportingDocuments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCostings",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FOBValueForeignCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOBValueExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOBValueBDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OceanAirFreightForeignCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OceanAirFreightExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OceanAirFreightBDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HandlingOtherChargesForeignCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HandlingOtherChargesExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HandlingOtherChargesBDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceForeignCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceBDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CIFBridgeTown = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDutiesTaxesExclusiveVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotalA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InlandFreight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherCurrentShipment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherPreviousShipmentRR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCostBDSBeforeVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandedCostFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceCostings_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Costing",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceCostings_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceCostings_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDiscrepancies",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: true),
                    DiscrepancyStatusId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDiscrepancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscrepancies_DiscrepancyStatuses_DiscrepancyStatusId",
                        column: x => x.DiscrepancyStatusId,
                        principalSchema: "Lookup",
                        principalTable: "DiscrepancyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscrepancies_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Costing",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscrepancies_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalSchema: "Lookup",
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscrepancies_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscrepancies_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePackages",
                schema: "Costing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PackageTypeId = table.Column<int>(type: "int", nullable: true),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePackages_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Costing",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicePackages_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalSchema: "Lookup",
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicePackages_PackageTypes_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalSchema: "Lookup",
                        principalTable: "PackageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicePackages_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicePackages_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCostings_CreatedBy",
                schema: "Costing",
                table: "InvoiceCostings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCostings_InvoiceId",
                schema: "Costing",
                table: "InvoiceCostings",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCostings_UpdatedBy",
                schema: "Costing",
                table: "InvoiceCostings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscrepancies_CreatedBy",
                schema: "Costing",
                table: "InvoiceDiscrepancies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscrepancies_DiscrepancyStatusId",
                schema: "Costing",
                table: "InvoiceDiscrepancies",
                column: "DiscrepancyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscrepancies_InvoiceId",
                schema: "Costing",
                table: "InvoiceDiscrepancies",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscrepancies_MeasurementUnitId",
                schema: "Costing",
                table: "InvoiceDiscrepancies",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscrepancies_UpdatedBy",
                schema: "Costing",
                table: "InvoiceDiscrepancies",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackages_CreatedBy",
                schema: "Costing",
                table: "InvoicePackages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackages_InvoiceId",
                schema: "Costing",
                table: "InvoicePackages",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackages_MeasurementUnitId",
                schema: "Costing",
                table: "InvoicePackages",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackages_PackageTypeId",
                schema: "Costing",
                table: "InvoicePackages",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackages_UpdatedBy",
                schema: "Costing",
                table: "InvoicePackages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CreatedBy",
                schema: "Costing",
                table: "Invoices",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                schema: "Costing",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReceivingReportId",
                schema: "Costing",
                table: "Invoices",
                column: "ReceivingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UpdatedBy",
                schema: "Costing",
                table: "Invoices",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_CreatedBy",
                schema: "Costing",
                table: "ReceivingReports",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_ReceivingReportStatusId",
                schema: "Costing",
                table: "ReceivingReports",
                column: "ReceivingReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_SupplierId",
                schema: "Costing",
                table: "ReceivingReports",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_UpdatedBy",
                schema: "Costing",
                table: "ReceivingReports",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CreatedBy",
                schema: "Subscription",
                table: "Subscriptions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UpdatedBy",
                schema: "Subscription",
                table: "Subscriptions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatedBy",
                schema: "Costing",
                table: "Suppliers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UpdatedBy",
                schema: "Costing",
                table: "Suppliers",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupportingDocuments_CreatedBy",
                schema: "Costing",
                table: "SupportingDocuments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupportingDocuments_ReceivingReportId",
                schema: "Costing",
                table: "SupportingDocuments",
                column: "ReceivingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportingDocuments_UpdatedBy",
                schema: "Costing",
                table: "SupportingDocuments",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceCostings",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "InvoiceDiscrepancies",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "InvoicePackages",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "SupportingDocuments",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "DiscrepancyStatuses",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "MeasurementUnits",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "PackageTypes",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "InvoiceTypes",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "ReceivingReports",
                schema: "Costing");

            migrationBuilder.DropTable(
                name: "ReceivingReportStatuses",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Costing");
        }
    }
}
