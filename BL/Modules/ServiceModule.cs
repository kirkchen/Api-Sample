using ApiSample.BL.Interfaces;
using ApiSample.BL.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;
using ApiSample.Utility.Extensions.Aop;

namespace ApiSample.BL.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var service = Assembly.Load("ApiSample.BL.Services");

            builder.RegisterAssemblyTypes(service)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors();

            builder.RegisterType<ProductService>()
                   .As<IProductService>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(LogInterceptor), typeof(AuthInterceptor));
        }
    }
}
