using CostingManagement.Data.DbModels.SecuritySchema;
using CostingManagement.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CostingManagement.Data.DataContext
{
    public class DataSeedingIntilization
    {
        private static AppDbContext _appDbContext;
        private static UserManager<ApplicationUser> _userManager;
        private static IServiceProvider _serviceProvider;

        public static void Seed(AppDbContext appDbContext, IServiceProvider serviceProvider)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.Migrate();
            _serviceProvider = serviceProvider;

            var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            _userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            // call functions
            SeedApplicationRoles();
            SeedApplicationSuperAdmin();

            // save to the database
            _appDbContext.SaveChanges();
        }

        private static void SeedApplicationRoles()
        {
            var items = _appDbContext.Roles.ToList();
            if (items == null || items.Count == 0)
            {
                string[] names = Enum.GetNames(typeof(ApplicationRolesEnum));
                ApplicationRolesEnum[] values = (ApplicationRolesEnum[])Enum.GetValues(typeof(ApplicationRolesEnum));

                for (int i = 0; i < names.Length; i++)
                {
                    _appDbContext.Roles.Add(new ApplicationRole() { Id = (int)values[i], Name = names[i], NormalizedName = names[i].ToUpper() });
                }
                _appDbContext.SaveChanges();
            }

        }
        private static void SeedApplicationSuperAdmin()
        {
            var superAdmin = _userManager.FindByNameAsync("admin@gmail.com");
            if (superAdmin.Result == null)
            {
                var applicationUser = new ApplicationUser()
                {
                    EmailConfirmed = true,
                    Status = UserStatusEnum.Active.ToString(),
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    CreatedBy = null,
                    CreatedOn = DateTime.Now,
                };

                var result = _userManager.CreateAsync(applicationUser, "Admin@2010");
                if (result.Result.Succeeded)
                {
                    superAdmin = _userManager.FindByEmailAsync("admin@gmail.com");
                    _appDbContext.UserRoles.Add(new ApplicationUserRole { RoleId = (int)ApplicationRolesEnum.SuperAdmin, UserId = superAdmin.Result.Id });
                }
            }

        }
    }
}
