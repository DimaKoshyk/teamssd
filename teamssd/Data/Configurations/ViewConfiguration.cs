using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class ViewConfiguration : EntityTypeConfiguration<View>
    {
        public ViewConfiguration()
        {
            ToTable("Views");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.ViewedNews)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.News)
                .WithMany(x => x.Viewers)
                .HasForeignKey(x => x.NewsId)
                .WillCascadeOnDelete(false);
        }
    }
}