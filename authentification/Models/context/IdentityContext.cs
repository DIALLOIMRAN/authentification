using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

namespace authentification.Models
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, int,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new ApplicationDbInitializer());
            var type = typeof(SqlProviderServices);
            //ConfigureContext();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.HasDefaultSchema("NAM");
            base.OnModelCreating(modelBuilder);
            // Ajout des configurations pour le mappage des tables de la base de données
            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new OrdersConfiguration());


            //modelBuilder.Configurations.Add(new UsersRolesConfiguration());
            //modelBuilder.Configurations.Add(new UsersClemsConfiguration());
            //modelBuilder.Configurations.Add(new UsersLoginsConfiguration());

            //modelBuilder.HasDefaultSchema("dbo");

            //modelBuilder.Entity<ApplicationUserLogin>().Map(c =>
            //{
            //    c.ToTable("UserLogin");
            //    c.Properties(p => new
            //    {
            //        p.UserId,
            //        p.LoginProvider,
            //        p.ProviderKey
            //    });
            //}).HasKey(p => new { p.LoginProvider, p.ProviderKey, p.UserId });

            // Mapping for ApiRole
            //modelBuilder.Entity<ApplicationRole>().Map(c =>
            //{
            //    c.ToTable("Role");
            //    c.Property(p => p.Id).HasColumnName("RoleId");
            //    c.Properties(p => new
            //    {
            //        p.Name
            //    });
            //}).HasKey(p => p.Id);
            //modelBuilder.Entity<ApplicationRole>().HasMany(c => c.Users).WithRequired().HasForeignKey(c => c.RoleId);

            //modelBuilder.Entity<ApplicationUser>().Map(c =>
            //{
            //    c.ToTable("User");
            //    c.Property(p => p.Id).HasColumnName("UserId");
            //    c.Properties(p => new
            //    {
            //        p.AccessFailedCount,
            //        p.Email,
            //        p.EmailConfirmed,
            //        p.PasswordHash,
            //        p.PhoneNumber,
            //        p.PhoneNumberConfirmed,
            //        p.TwoFactorEnabled,
            //        p.SecurityStamp,
            //        p.LockoutEnabled,
            //        p.LockoutEndDateUtc,
            //        p.UserName
            //    });
            //}).HasKey(c => c.Id);
            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);
            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);


            //modelBuilder.Entity<ApplicationUserRole>().Map(c =>
            //{
            //    c.ToTable("UserRole");
            //    c.Properties(p => new
            //    {
            //        p.UserId,
            //        p.RoleId
            //    });
            //}).HasKey(c => new { c.UserId, c.RoleId });
            //modelBuilder.Entity<ApplicationUserClaim>().Map(c =>
            //{
            //    c.ToTable("UserClaim");
            //    c.Property(p => p.Id).HasColumnName("UserClaimId");
            //    c.Properties(p => new
            //    {
            //        p.UserId,
            //        p.ClaimValue,
            //        p.ClaimType
            //    });
            //}).HasKey(c => c.Id);



        }
        public virtual void ConfigureContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            //Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.UseDatabaseNullSemantics = false;
        }
    }
    
}