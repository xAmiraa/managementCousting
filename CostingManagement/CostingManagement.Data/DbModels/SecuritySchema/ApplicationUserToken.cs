using Microsoft.AspNetCore.Identity;

namespace CostingManagement.Data.DbModels.SecuritySchema
{
    public class ApplicationUserToken: IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
