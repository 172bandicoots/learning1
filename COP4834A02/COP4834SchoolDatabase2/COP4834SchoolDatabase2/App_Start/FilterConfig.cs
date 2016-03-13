using System.Web;
using System.Web.Mvc;

namespace COP4834SchoolDatabase2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
