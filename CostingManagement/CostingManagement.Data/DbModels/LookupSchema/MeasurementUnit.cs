using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("MeasurementUnits", Schema = "Lookup")]
    public class MeasurementUnit: StaticLookup  // cubic , meters, inches
    {
        public MeasurementUnit()
        {
            InvoicePackages = new HashSet<InvoicePackage>();
            InvoiceDiscrepancies = new HashSet<InvoiceDiscrepancy>();
        }
        public virtual ICollection<InvoicePackage> InvoicePackages { get; set; }
        public virtual ICollection<InvoiceDiscrepancy> InvoiceDiscrepancies { get; set; }
    }
}
