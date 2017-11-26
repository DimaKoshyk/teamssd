using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class InterestNewsConfiguration : EntityTypeConfiguration<InterestNews>
    {
        public InterestNewsConfiguration()
        {
            ToTable("InterestNews");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.InterestNews)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.News)
                .WithMany(x => x.InterestNews)
                .HasForeignKey(x => x.NewsId)
                .WillCascadeOnDelete(false);
        }
    }
}