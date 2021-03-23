using CostingManagement.Data.BaseModeling;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("Suppliers", Schema = "Costing")]
    public class Supplier : DefaultIdAuditableEntity
    {
        public Supplier()
        {
            ReceivingReports = new HashSet<ReceivingReport>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ReceivingReport> ReceivingReports { get; set; }
    }
}
