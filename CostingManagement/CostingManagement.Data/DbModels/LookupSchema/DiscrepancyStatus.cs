using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("DiscrepancyStatuses", Schema = "Lookup")]
    public class DiscrepancyStatus: DynamicLookup
    {
        public DiscrepancyStatus()
        {
            InvoiceDiscrepancies = new HashSet<InvoiceDiscrepancy>();
        }

        public virtual ICollection<InvoiceDiscrepancy> InvoiceDiscrepancies { get; set; }
    }
}
