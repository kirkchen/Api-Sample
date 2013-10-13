using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace ApiSample.Utility.Extensions.Elmah
{
    public class IPConstraint : IRouteConstraint
    {
        private string[] ipList = new string[] { };

        public IPConstraint(string allowedIps)
        {
            ipList = allowedIps.Split(',', ';');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string clientIp = httpContext.Request.UserHostAddress;
            if (!ipList.Contains(clientIp))
            {
                throw new UnauthorizedAccessException("Disallowed Client IP!");
            }

            return true;
        }
    }
}
