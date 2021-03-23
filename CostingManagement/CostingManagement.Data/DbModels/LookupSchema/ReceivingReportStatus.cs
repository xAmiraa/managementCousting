using CostingManagement.Data.BaseModeling;
using CostingManagement.Data.DbModels.CostingSchema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.LookupSchema
{
    [Table("ReceivingReportStatuses", Schema = "Lookup")]
    public class ReceivingReportStatus : StaticLookup // initaited , open , pending, confirmed, accounts, pending verification
    {
        public ReceivingReportStatus()
        {
            ReceivingReports = new HashSet<ReceivingReport>();
        }
        public virtual ICollection<ReceivingReport> ReceivingReports { get; set; }
    }
}
