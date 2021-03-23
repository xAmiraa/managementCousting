using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.LookupSchema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("InvoicePackages", Schema = "Costing")]
    public class InvoicePackage : DefaultIdAuditableEntity
    {
        public string PackageNumber { get; set; }
        [Required]
        public string Measurement { get; set; }
        public string Description { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; } // cubic , meters, inches
    }
}
