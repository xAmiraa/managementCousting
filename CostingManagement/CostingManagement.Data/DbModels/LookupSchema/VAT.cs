using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("VATs", Schema = "Lookup")]
    public class VAT : DefaultIdAuditableEntity
    {
        public VAT()
        {
            InvoiceCostings = new HashSet<InvoiceCosting>();
        }
        public decimal VatPercentage { get; set; }

        public virtual ICollection<InvoiceCosting> InvoiceCostings { get; set; }
    }
}
