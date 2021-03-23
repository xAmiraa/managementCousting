using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.LookupSchema;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("InvoiceDiscrepancies", Schema = "Costing")]
    public class InvoiceDiscrepancy : DefaultIdAuditableEntity
    {
        public string ItemNumber { get; set; }
        public decimal Cost { get; set; }
        public string Measurement { get; set; }
        public string Description { get; set; }


        public virtual Invoice Invoice { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
        public virtual DiscrepancyStatus DiscrepancyStatus { get; set; }
    }
}
