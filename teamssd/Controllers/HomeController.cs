using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
using teamssd.Data.Entities;
using teamssd.Models;

namespace teamssd.Controllers
{
    public class NewsFilter
    {
        public int? ChanelId { get; set; }

    }

    public class HomeController : GeneralController
    {

        private int GetCountOfNews(int? page)
        {
            if (page == null || page.Value < 0)
            {
                page = 0;
            }

            return 10 * page.Value;
        }

        private IList<News> GetNews(bool isMy, int? chanelId, int? page)
        {
            IQueryable<News> news = Db.Newses;

            if (isMy)
            {
                news = news.Where(x => x.Chanel.OwnerId == CurrentUser.Id);
            }
            else
            {
                news = news.Where(x => x.Chanel.Followers.Any(y => y.OwnerId == CurrentUser.Id));
            }

            if (chanelId.HasValue)
            {
                news = news.Where(x => x.ChanelId == chanelId.Value);
            }

            var skipNews = GetCountOfNews(page);

            return news
                .OrderByDescending(x => (x.InterestsСount + x.RelevantsСount + x.UsefulsСount) / (DbFunctions.DiffHours(DateTime.Now, x.DateTime) + 1))
                .Skip(skipNews)
                .Take(10)
                .ToList();
        }

        public ActionResult Index()
        {
            //ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name", );
            //var model = new DashboardViewModels();

            //model.Chanels = CurrentUser.Chanels.ToList();
            //var firstChanel = model.Chanels.FirstOrDefault();
            //model.NewsOfFirstChanel = firstChanel?.News.ToList() ?? new List<News>();

            return News();
        }

        public ActionResult MyNews()
        {
            ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name");
            ViewBag.MyNews = true;

            var model = new DashboardViewModels();
            model.News = GetNews(true, null, 0);

            return View("Index", model);
        }

        public ActionResult News()
        {
            ViewBag.News = true;
            ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)), "Id", "Name");

            var model = new DashboardViewModels();
            model.News = GetNews(false, null, 0);

            return View("Index", model);
        }

        public ActionResult ViewedNews()
        {
            ViewBag.ViewedNews = true;
            ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)), "Id", "Name");

            return NotFound404();
            //return View("Index", model);
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

        public ViewResult NotFound404()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ViewResult InternalServerError500()
        {
            return View();
        }
    }
}