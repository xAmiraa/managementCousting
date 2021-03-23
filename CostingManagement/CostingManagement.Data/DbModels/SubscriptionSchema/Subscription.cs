using CostingManagement.Data.BaseModeling;
using System.ComponentModel.DataAnnotations.Schema;


namespace CostingManagement.Data.DbModels.SubscriptionSchema
{
    [Table("Subscriptions", Schema = "Subscription")]
    public class Subscription : DefaultIdAuditableEntity
    {
        public string LocalAdmin { get; set; }
        public string SuperAdmin { get; set; }
    }
}
