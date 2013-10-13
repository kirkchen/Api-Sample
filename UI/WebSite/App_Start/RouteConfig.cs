using ApiSample.Utility.Extensions.Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApiSample.UI.WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var namespaces = new[] { "Elmah.Mvc" };
            var elmahRoute = "Errors";
            string allowedIps = "::1;127.0.0.1";

            routes.MapRoute(
                "Elmah.Override",
                string.Format("{0}/{{resource}}", elmahRoute),
                new
                {
                    controller = "Elmah",
                    action = "Index",
                    resource = UrlParameter.Optional
                },
                new { resource = new IPConstraint(allowedIps) },
                namespaces);

            routes.MapRoute(
                "Elmah.Override.Detail",
                string.Format("{0}/detail/{{resource}}", elmahRoute),
                new
                {
                    controller = "Elmah",
                    action = "Detail",
                    resource = UrlParameter.Optional
                },
                new { resource = new IPConstraint(allowedIps) },
                namespaces);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Sample", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}