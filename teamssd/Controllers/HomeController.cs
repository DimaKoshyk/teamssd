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
            ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name");

            var model = new DashboardViewModels();

            model.Chanels = CurrentUser.Chanels.ToList();
            var firstChanel = model.Chanels.FirstOrDefault();
            model.NewsOfFirstChanel = firstChanel?.News.ToList() ?? new List<News>();

            return View(model);
        }

        //public ActionResult MyNews()
        //{
            
        //}

        //public ActionResult News()
        //{

        //}

        //public ActionResult ViewedNews()
        //{
        //    In
        //}

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
    }
}