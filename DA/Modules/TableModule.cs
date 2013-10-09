using ApiSample.DA.Tables;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Modules
{
    public class TableModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<ShopContext>()
                   .As<ShopContext>()
                   .InstancePerHttpRequest();
        }
    }
}
