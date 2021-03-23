using Microsoft.AspNetCore.Identity;

namespace CostingManagement.Data.DbModels.SecuritySchema
{
    public class ApplicationUserClaim: IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
