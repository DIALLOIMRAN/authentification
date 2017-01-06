#region liste de bibliothèques utilisés
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
#endregion

namespace authentification.Models
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<int>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, 
                                        IUserStore<ApplicationUser, int>, 
                                        IDisposable
    {
        public ApplicationUserStore() : this(new IdentityDbContext())
        {
            DisposeContext = true;
        }
        public ApplicationUserStore(DbContext context) : base(context) { }
    }
} // end namespace