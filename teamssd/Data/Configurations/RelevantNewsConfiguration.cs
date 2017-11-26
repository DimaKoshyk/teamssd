using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class RelevantNewsConfiguration : EntityTypeConfiguration<RelevantNews>
    {
        public RelevantNewsConfiguration()
        {
            ToTable("RelevantNews");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.RelevantNews)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.News)
                .WithMany(x => x.RelevantNews)
                .HasForeignKey(x => x.NewsId)
                .WillCascadeOnDelete(false);
        }
    }
}