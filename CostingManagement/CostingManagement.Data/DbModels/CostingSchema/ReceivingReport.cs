using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.LookupSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("ReceivingReports", Schema = "Costing")]
    public class ReceivingReport : DefaultIdAuditableEntity
    {
        public ReceivingReport()
        {
            Invoices = new HashSet<Invoice>();
            SupportingDocuments = new HashSet<SupportingDocument>();
        }
        [Required]
        public string RRNumber { get; set; } // auto generated number by the system [00001, 00002 ...etc]
        [Required]
        public string QueueNumber { get; set; } // auto generated number
        [Required]
        public DateTime DateReceived { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string GrnReferenceNumber { get; set; }
        public string Notes { get; set; }
        public string DeleteReason { get; set; }


        public virtual Supplier Supplier { get; set; }
        public virtual ReceivingReportStatus ReceivingReportStatus { get; set; }// initaited , open , pending, confirmed, accounts, pending verification
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<SupportingDocument> SupportingDocuments { get; set; }
    }
}
