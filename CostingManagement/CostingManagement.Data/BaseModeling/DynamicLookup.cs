using CostingManagement.Core.Interfaces;

namespace CostingManagement.Data.BaseModeling
{
  public  class DynamicLookup : ILookupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
