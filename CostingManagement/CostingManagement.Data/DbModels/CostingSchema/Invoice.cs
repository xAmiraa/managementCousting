using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.LookupSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("Invoices", Schema = "Costing")]
    public class Invoice : DefaultIdAuditableEntity
    {
        public Invoice()
        {
            InvoicePackages = new HashSet<InvoicePackage>();
            InvoiceDiscrepancies = new HashSet<InvoiceDiscrepancy>();
        }
        [Required]
        public string InvoiceNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }

        public virtual ReceivingReport ReceivingReport { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
        public virtual ICollection<InvoicePackage> InvoicePackages { get; set; }
        public virtual ICollection<InvoiceDiscrepancy> InvoiceDiscrepancies { get; set; } // as long as invoice does not have discrepancies then status is good, else not good
    }
}
