using CostingManagement.Core.Interfaces;

namespace CostingManagement.Data.BaseModeling
{
   public class BaseEntity : IBaseEntity
    {
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
    }
}
