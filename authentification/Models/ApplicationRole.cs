#region liste de bibliothèques utilisés
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
#endregion
namespace authentification.Models
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IRole<int>
    {
        public string Description { get; set; }

        public ApplicationRole() : base() { }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationRole(string name, string description)
            : this(name)
        {
            this.Description = description;
        }
    } // end class ApplicationRole
    public class ApplicationRoleStore : RoleStore<ApplicationRole, int,  ApplicationUserRole>, 
                                        IQueryableRoleStore<ApplicationRole, int>, 
                                        IRoleStore<ApplicationRole, int>, 
                                        IDisposable
    {
        public ApplicationRoleStore() : base(new IdentityDbContext())
        {
            DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context) : base(context)
        {
        }
    } // end class ApplicationRoleStore
} // end namespace