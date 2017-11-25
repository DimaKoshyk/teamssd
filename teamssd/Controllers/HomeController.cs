using System.Linq;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
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
    }
}