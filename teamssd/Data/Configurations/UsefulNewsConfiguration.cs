using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class UsefulNewsConfiguration : EntityTypeConfiguration<UsefulNews>
    {
        public UsefulNewsConfiguration()
        {
            ToTable("UsefulNews");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.UsefulNews)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.News)
                .WithMany(x => x.UsefulNews)
                .HasForeignKey(x => x.NewsId)
                .WillCascadeOnDelete(false);
        }
    }
}