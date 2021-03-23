using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CostingManagement.Data.DbModels.SecuritySchema
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Claims = new HashSet<ApplicationUserClaim>();
            Logins = new HashSet<ApplicationUserLogin>();
            Tokens = new HashSet<ApplicationUserToken>();
            UserRoles = new HashSet<ApplicationUserRole>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalImagePath { get; set; }
        public bool ChangePassword { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Status { get; set; } // Active, NotActive, Locked

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
