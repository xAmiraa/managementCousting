using CostingManagement.Data.BaseModeling;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.DbModels.CostingSchema
{
    [Table("SupportingDocuments", Schema = "Costing")]
    public class SupportingDocument : DefaultIdAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }

        public virtual ReceivingReport ReceivingReport { get; set; }
    }
}
