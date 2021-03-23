using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("InvoiceTypes", Schema = "Lookup")]
    public class InvoiceType : StaticLookup
    {
        public InvoiceType()
        {
            Invoices = new HashSet<Invoice>();
        }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
