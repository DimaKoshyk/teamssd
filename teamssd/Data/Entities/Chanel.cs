using System.Collections.Generic;
using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class Chanel : Entity<int>
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Owner { get; set; }


        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
