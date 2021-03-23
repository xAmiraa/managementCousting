using CostingManagement.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostingManagement.Data.BaseModeling
{
  public class StaticLookup : ILookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
