using System.Web;
using System.Web.Mvc;

namespace flightSearchEngine_back
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
