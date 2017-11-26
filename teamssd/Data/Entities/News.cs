using System;
using System.Collections.Generic;
using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class News : Entity<int>
    {
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }
        public string Video { get; set; }
        public string UrlRef { get; set; }

        //public string OwnerId { get; set; }
        //public virtual ApplicationUser Owner { get; set; }

        public int InterestsСount { get; set; }
        public int RelevantsСount { get; set; }
        public int UsefulsСount { get; set; }

        public int ViewsCount { get; set; }

        public int Rating { get; set; }


        public int ChanelId { get; set; }
        public virtual Chanel Chanel { get; set; }

        public virtual ICollection<View> Viewers { get; set; }

        public virtual ICollection<InterestNews> InterestNews { get; set; }
        public virtual ICollection<RelevantNews> RelevantNews { get; set; }
        public virtual ICollection<UsefulNews> UsefulNews { get; set; }
    }
}
