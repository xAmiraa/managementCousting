using Microsoft.AspNetCore.Identity;

namespace CostingManagement.Data.DbModels.SecuritySchema
{
    public class ApplicationRoleClaim: IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
