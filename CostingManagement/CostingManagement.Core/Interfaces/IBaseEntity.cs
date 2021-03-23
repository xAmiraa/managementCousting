using System;
using System.Collections.Generic;
using System.Text;

namespace CostingManagement.Core.Interfaces
{
    public interface IBaseEntity
    {
        bool IsDeleted { get; set; }
        int Id { get; set; }
    }
}
