using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Modules
{
    public class ExtensionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mappings = Assembly.Load("ApiSample.Utility.Extensions");

            builder.RegisterAssemblyTypes(mappings)
                   .AsImplementedInterfaces();
        }
    }
}
