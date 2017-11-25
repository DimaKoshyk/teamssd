using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class FollowerConfiguration : EntityTypeConfiguration<Follower>
    {
        public FollowerConfiguration()
        {
            ToTable("Followers");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.FollowedChanels)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Chanel)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.ChanelId)
                .WillCascadeOnDelete(false);
        }
    }
}