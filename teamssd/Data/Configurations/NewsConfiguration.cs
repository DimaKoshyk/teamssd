using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class NewsConfiguration : EntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        {
            ToTable("News");
            HasKey(x => x.Id);

            HasRequired(x => x.Chanel)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.ChanelId)
                .WillCascadeOnDelete(false);
        }
    }
}