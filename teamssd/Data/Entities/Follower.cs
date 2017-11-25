using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class Follower : Entity<int>
    {
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public int ChanelId { get; set; }
        public virtual Chanel Chanel { get; set; }
    }
}
