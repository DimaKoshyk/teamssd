using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class InterestNews : Entity<int>
    {
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
