using System.Collections.Generic;
using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class News : Entity<int>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }
        public string Video { get; set; }
        public string UrlRef { get; set; }

        //public string OwnerId { get; set; }
        //public virtual ApplicationUser Owner { get; set; }

        public int ChanelId { get; set; }
        public virtual Chanel Chanel { get; set; }

        public ICollection<View> Viewers { get; set; }
    }
}
