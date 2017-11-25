using System.Web.Mvc;
using teamssd.Filters;

namespace teamssd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleAuth());
        }
    }
}
