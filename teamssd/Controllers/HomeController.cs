using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
using teamssd.Data.Entities;
using teamssd.Models;

namespace teamssd.Controllers
{
    public class HomeController : GeneralController
    {
        public ActionResult Index()
        {
            var model = new DashboardViewModels();

            model.Chanels = CurrentUser.Chanels.ToList();
            var firstChanel = model.Chanels.FirstOrDefault();
            if (firstChanel != null)
            {
                model.NewsOfFirstChanel = firstChanel.News.ToList();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //for test
            var usersQ = Db.Views.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //.Select(x => new NewsDto
        //{
        //    DateTime = x.DateTime,
        //    Title = x.Title,
        //    Text = x.Text,
        //    InterestsСount = interestsСount,
        //    RelevantsСount = relevantsСount,
        //    UsefulsСount = usefulsСount,
        //    ViewsCount = viewsCount,

        //    //Rating = InterestsСount,});
        //фільтрування новин
        private DashboardViewModels GetDashboardViewModels(IQueryable<News> news)
        {
            var currentUserId = CurrentUser.Id;
            var model = new DashboardViewModels();

            var newsDtos = news.Where(x => x.Viewers.Any(y => y.OwnerId != currentUserId));
            

            //model.DashboardNews = newsDtos.Take(100).OrderBy(x => x.DateTime).ToList();
            model.NewsOfFirstChanel = newsDtos.OrderBy(x =>  x.Rating / ((DateTime.Now - x.DateTime).TotalHours + 1)).Take(100).ToList();


            return model;
        }
    }

    public class NewsDto
    {
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int InterestsСount { get; set; }
        public int RelevantsСount { get; set; }
        public int UsefulsСount { get; set; }

        public int ViewsCount { get; set; }

        public int Rating { get; set; }
    }
}