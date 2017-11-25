using System.Web.Mvc;
using System.Web.Routing;

namespace teamssd.Filters
{

    public class HandleAuth : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login", area = "" }));
            }
        }
    }
}