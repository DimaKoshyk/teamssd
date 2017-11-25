using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Payzaar.Core.Data.Abstract;
using teamssd.Data.Enum;

namespace teamssd.Data.Entities
{
    public class Chanel : Entity<int>
    {
        [DisplayName ("Назва каналу")]
        public string Name { get; set; }
        [DisplayName("Опис")]
        public string Description { get; set; }

        public ChanelType ChanelType { get; set; }
        public string Location { get; set; }

        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }


        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
