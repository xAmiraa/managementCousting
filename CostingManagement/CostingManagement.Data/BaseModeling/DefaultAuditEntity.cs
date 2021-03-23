using CostingManagement.Data.DbModels.SecuritySchema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.BaseModeling
{
    public class DefaultAuditEntity
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }
        public string Action { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public int ActionedBy { get; set; }
        public virtual ApplicationUser Creator { get; set; }
    }
}
