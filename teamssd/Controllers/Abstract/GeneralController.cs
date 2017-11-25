using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity.Owin;
using teamssd.Data;
using teamssd.Data.Entities;

namespace teamssd.Controllers.Abstract
{
    public abstract class GeneralController : Controller
    {
        // GET: General
        private ApplicationUserManager _applicationUserManager;
        public readonly ApplicationDbContext Db = new ApplicationDbContext();
        public ApplicationUser CurrentUser { get; set; }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _applicationUserManager ?? (_applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
            protected set
            {
                _applicationUserManager = value;
            }
        }

        protected override void Initialize(RequestContext rc)
        {
            var context = rc.HttpContext;
            var identity = context.User.Identity;

            if (!string.IsNullOrEmpty(identity.Name))
            {
                CurrentUser = Db.Users.FirstOrDefault(x => x.UserName == identity.Name);
            }
            base.Initialize(rc);

            if (CurrentUser != null)
            {
                ViewBag.CurrentUser = CurrentUser;
            }
        }
    }
}