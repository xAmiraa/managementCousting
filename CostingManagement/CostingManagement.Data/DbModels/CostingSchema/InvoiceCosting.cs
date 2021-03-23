using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.LookupSchema;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("InvoiceCostings", Schema = "Costing")]
    public class InvoiceCosting : DefaultIdAuditableEntity
    {
        // F.O.B
        public decimal FOBValueForeignCurrency { get; set; }
        public decimal FOBValueExchangeRate { get; set; }
        public decimal FOBValueBDS { get; set; }

        // OCEAN / AIR FREIGHT
        public decimal OceanAirFreightForeignCurrency { get; set; }
        public decimal OceanAirFreightExchangeRate { get; set; }
        public decimal OceanAirFreightBDS { get; set; }

        // HANDLING / OTHER CHARGES
        public decimal HandlingOtherChargesForeignCurrency { get; set; }
        public decimal HandlingOtherChargesExchangeRate { get; set; }
        public decimal HandlingOtherChargesBDS { get; set; }

        // INSURANCE
        public decimal InsuranceForeignCurrency { get; set; }
        public decimal InsuranceExchangeRate { get; set; }
        public decimal InsuranceBDS { get; set; }

        // Rest of properties
        public decimal CIFBridgeTown { get; set; }
        public decimal TotalDutiesTaxesExclusiveVat { get; set; }
        public decimal SubTotalA { get; set; }
        public decimal InlandFreight { get; set; }
        public decimal CustomFees { get; set; }
        public decimal OtherCurrentShipment { get; set; }
        public decimal OtherPreviousShipmentRR { get; set; }
        public decimal TotalCostBDSBeforeVat { get; set; }
        public decimal Vat { get; set; }
        public string Notes { get; set; }
        public decimal LandedCostFactor { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual VAT VAT { get; set; }
    }
}
