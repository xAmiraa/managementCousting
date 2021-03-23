using CostingManagement.Data.DbModels.SecuritySchema;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.BaseModeling
{
   public class BaseAuditableEntity : BaseEntity
    {
        [ForeignKey("Creator")]
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [ForeignKey("Updator")]
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ApplicationUser Creator { get; set; }
        public virtual ApplicationUser Updator { get; set; }
    }
}
