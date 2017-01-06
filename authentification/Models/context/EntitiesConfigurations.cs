using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace authentification.Models
{
    public class OrdersConfiguration : EntityTypeConfiguration<Orders>
    {
        public OrdersConfiguration()
        {
            ToTable("Orders");
            HasKey(e => e.OrderID);
            Property(t => t.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.CustomerName).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            Property(r => r.ShipperCity).IsRequired().HasMaxLength(50).HasColumnType("varchar");
        }
    }

    public class RolesConfiguration : EntityTypeConfiguration<ApplicationRole>
    {
        public RolesConfiguration()
        {
            ToTable("Roles");
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany((ApplicationRole u) => u.Users).WithRequired().HasForeignKey(c => c.RoleId); ;
        }
    }

    public class UsersConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UsersConfiguration()
        {
            ToTable("Users");
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AccessFailedCount).HasColumnType("integer");
            Property(e => e.UserName).IsRequired().HasColumnType("varchar");
            Property(e => e.Email).IsRequired().HasColumnType("varchar");
            Property(e => e.EmailConfirmed).HasColumnType("BOOLEAN");
            Property(e => e.PasswordHash).HasColumnType("varchar");
            Property(e => e.PasswordHash).HasColumnType("varchar");
            Property(e => e.PhoneNumber).HasColumnType("varchar");
            Property(e => e.PhoneNumberConfirmed).HasColumnType("BOOLEAN");
            Property(e => e.TwoFactorEnabled).HasColumnType("BOOLEAN");
            Property(e => e.SecurityStamp).HasColumnType("varchar");
            Property(e => e.LockoutEnabled).HasColumnType("varchar");
            Property(e => e.LockoutEndDateUtc).IsOptional();
            //HasMany(c => c.Roles).Map(m => m.ToTable("UserLogin").MapLeftKey("CourseId").MapRightKey("StudentId"));

            HasMany((ApplicationUser u) => u.Roles).WithOptional().HasForeignKey(c => c.UserId);
            HasMany((ApplicationUser u) => u.Logins).WithOptional().HasForeignKey(c => c.UserId);
            HasMany((ApplicationUser u) => u.Claims).WithOptional().HasForeignKey(c => c.UserId);

            //HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
        }
    }

    public class UsersRolesConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public UsersRolesConfiguration()
        {
            //ToTable("users_roles");
            //HasKey(e => new { e.UserId, e.RoleId });
            HasKey((ApplicationUserRole r) => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("UserRoles");

        }
    }

    public class UsersClemsConfiguration : EntityTypeConfiguration<ApplicationUserClaim>
    {
        public UsersClemsConfiguration()
        {
            //ToTable("UserClems");
            //HasKey(e => new { e.Id, e.UserId });
            HasKey((ApplicationUserClaim r) => new {Id = r.Id,  UserId = r.UserId }).ToTable("UserClems");
        }
    }

    public class UsersLoginsConfiguration : EntityTypeConfiguration<ApplicationUserLogin>
    {
        public UsersLoginsConfiguration()
        {
            //ToTable("UserLogins");
            //HasKey(e => new { e.UserId, e.LoginProvider, e.ProviderKey });
            HasKey((ApplicationUserLogin r) => new {UserId = r.UserId, LoginProvider=r.LoginProvider, ProviderKey=r.ProviderKey }).ToTable("UserLogins");
        }
    }
}