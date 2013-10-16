using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Logging.NLog.Autofac;

namespace ApiSample.UI.WebSite
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();            

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();            

            //// Enable inject web types, ex:HttpContext
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterModule(new NLogLoggerAutofacModule());

            //// Read autofac settings from config
            builder.RegisterModule(new ConfigurationSettingsReader());
            
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}