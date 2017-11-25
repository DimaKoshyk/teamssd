using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using teamssd.Data.Entities;


namespace teamssd.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        #region DB Sets

        //public virtual DbSet<Country> Countries { get; set; }
    

        #endregion

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public ApplicationDbContext(DbConnection connection, bool contextOwnsConnection)
           : base(connection, contextOwnsConnection)
        { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
        

            base.OnModelCreating(modelBuilder);
        }
    }
}
