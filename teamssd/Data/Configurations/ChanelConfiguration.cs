using System.Data.Entity.ModelConfiguration;
using teamssd.Data.Entities;

namespace teamssd.Data.Configurations
{
    public class ChanelConfiguration : EntityTypeConfiguration<Chanel>
    {
        public ChanelConfiguration()
        {
            ToTable("Chanels");
            HasKey(x => x.Id);

            HasRequired(x => x.Owner)
                .WithMany(x => x.Chanels)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);
        }
    }
}