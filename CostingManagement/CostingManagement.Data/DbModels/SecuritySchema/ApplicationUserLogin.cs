using Microsoft.AspNetCore.Identity;
namespace CostingManagement.Data.DbModels.SecuritySchema
{
    public class ApplicationUserLogin: IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
