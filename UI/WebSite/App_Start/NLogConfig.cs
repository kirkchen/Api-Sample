using ApiSample.Utility.Extensions.Nlog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSample.UI.WebSite
{
    public class NLogConfig
    {
        public static void Initialize()
        {
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("aspnetmvc-controller", typeof(ControllerLayoutRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("aspnetmvc-action", typeof(ActionLayoutRenderer));
        }
    }
}