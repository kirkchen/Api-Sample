using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Modules
{
    public class HookModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            //// Register Hooks
            var hooks = Assembly.Load("ApiSample.Utility.Hooks");
            builder.RegisterAssemblyTypes(hooks).AsImplementedInterfaces();            
        }
    }
}
