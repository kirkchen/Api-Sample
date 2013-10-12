using ApiSample.UI.WebSite.ActionFilters;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(DependencyResolver.Current.GetService<ValidateTokenAttribute>());           
            filters.Add(new HandleErrorAttribute());
        }
    }
}