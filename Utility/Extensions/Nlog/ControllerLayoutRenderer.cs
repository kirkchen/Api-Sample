using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiSample.Utility.Extensions.Nlog
{
    [LayoutRenderer("aspnetmvc-controller")]
    public class ControllerLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, NLog.LogEventInfo logEvent)
        {
            var controllerName = string.Empty;
            if (HttpContext.Current != null)
            {
                controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            }

            builder.Append(controllerName);
        }
    }
}
