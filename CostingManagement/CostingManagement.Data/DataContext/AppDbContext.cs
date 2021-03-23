using CostingManagement.Data.DbModels.CostingSchema;
using CostingManagement.Data.DbModels.LookupSchema;
using CostingManagement.Data.DbModels.SecuritySchema;
using CostingManagement.Data.DbModels.SubscriptionSchema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CostingManagement.Data.DataContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set application user relations
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });

            // set application role relations
            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // set application role primary key
                b.HasKey(u => u.Id);
                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            // set application user role primary key
            modelBuilder.Entity<ApplicationUserRole>(b =>
            {
                b.HasKey(u => u.Id);
            });

            // Update Identity Schema
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "Security");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles", "Security");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles", "Security");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins", "Security");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims", "Security");
            modelBuilder.Entity<ApplicationUserToken>().ToTable("UserTokens", "Security");
            modelBuilder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims", "Security");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        #region Lookup Schema
        public DbSet<DiscrepancyStatus> DiscrepancyStatuses { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<ReceivingReportStatus> ReceivingReportStatuses { get; set; }
        public DbSet<VAT> VATs { get; set; }
        #endregion

        #region Costing Schema
        public DbSet<ReceivingReport> ReceivingReports { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }
        public DbSet<InvoicePackage> InvoicePackages { get; set; }
        public DbSet<InvoiceDiscrepancy> InvoiceDiscrepancies { get; set; }
        public DbSet<InvoiceCosting> InvoiceCostings { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        #region Subscription
        public DbSet<Subscription> Subscriptions { get; set; }
        #endregion
    }
}
