using System.Collections.Generic;
using teamssd.Data.Entities;

namespace teamssd.Models
{
    public class DashboardViewModels
    {
        public IList<Chanel> Chanels { get; set; }

        public IList<News> NewsOfFirstChanel { get; set; }

        //public IList<RecommendChanel> RecommendChanels { get; set; }
    }
}