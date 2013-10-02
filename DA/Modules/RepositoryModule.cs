using ApiSample.DA.Interfaces;
using ApiSample.DA.Repositories;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleRepository>().As<ISampleRepository>();
        }
    }
}
