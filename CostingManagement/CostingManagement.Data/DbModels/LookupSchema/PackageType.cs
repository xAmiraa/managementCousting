using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("PackageTypes", Schema = "Lookup")]
    public class PackageType: DynamicLookup
    {
        public PackageType()
        {
            InvoicePackages = new HashSet<InvoicePackage>();
        }
        public virtual ICollection<InvoicePackage> InvoicePackages { get; set; }
    }
}
