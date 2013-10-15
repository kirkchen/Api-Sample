using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiSample.Utility.Extensions.Nlog
{
    public class DeveloperHackAuthAttribute : AuthorizeAttribute
    {
        private string[] ipList = new string[] { };
        private bool enableHack;

        public DeveloperHackAuthAttribute(string allowedIps, bool enable)
        {
            this.enableHack = enable;
            this.ipList = allowedIps.Split(',', ';');
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!this.enableHack)
            {
                return;
            }

            string clientIp = filterContext.HttpContext.Request.UserHostAddress;
            if (!ipList.Contains(clientIp))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(filterContext.HttpContext.Request.Headers["ApiHack-UserName"]) ||
                string.IsNullOrWhiteSpace(filterContext.HttpContext.Request.Headers["ApiHack-Groups"]))
            {
                return;
            }

            var username = filterContext.HttpContext.Request.Headers["ApiHack-UserName"];
            var groups = filterContext.HttpContext.Request.Headers["ApiHack-Groups"].Split(';');

            var identity = new GenericIdentity(username, "Basic");
            var principal = new GenericPrincipal(identity, groups);
            filterContext.HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;

            base.OnAuthorization(filterContext);
        }
    }
}
