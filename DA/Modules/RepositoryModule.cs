using ApiSample.DA.Interfaces;
using ApiSample.DA.Repositories;
using ApiSample.DA.Tables;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //// Register Repositories
            var repository = Assembly.Load("ApiSample.DA.Repositories");
            builder.RegisterAssemblyTypes(repository).AsImplementedInterfaces();

            //// Register Hooks
            var hooks = Assembly.Load("ApiSample.Utility.Hooks");
            builder.RegisterAssemblyTypes(hooks).AsImplementedInterfaces();

            builder.RegisterType<ShopContext>().As<ShopContext>();
        }
    }
}
