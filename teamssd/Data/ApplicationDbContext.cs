using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using teamssd.Data.Configurations;
using teamssd.Data.Entities;


namespace teamssd.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        #region DB Sets

        //public virtual DbSet<Country> Countries { get; set; }
        
            
        //public virtual DbSet<ApplicationUser>  ApplicationUsers{ get; set; }
        public virtual DbSet<Chanel> Chanels { get; set; }
        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<View> Views { get; set; }
    

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
            
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ChanelConfiguration());
            modelBuilder.Configurations.Add(new FollowerConfiguration());
            modelBuilder.Configurations.Add(new LikeConfiguration());
            modelBuilder.Configurations.Add(new NewsConfiguration());
            modelBuilder.Configurations.Add(new ViewConfiguration());
        

            base.OnModelCreating(modelBuilder);
        }
    }
}
