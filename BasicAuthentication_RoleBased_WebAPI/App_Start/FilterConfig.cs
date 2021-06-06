using System.Web;
using System.Web.Mvc;

namespace BasicAuthentication_RoleBased_WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
