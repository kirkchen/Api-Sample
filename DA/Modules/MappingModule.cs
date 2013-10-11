using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Modules
{
    public class MappingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mappings = Assembly.Load("ApiSample.DA.Mappings");

            builder.RegisterAssemblyTypes(mappings)
                   .Where(i => i.Name.EndsWith("MappingProfile"))
                   .AssignableTo<Profile>()
                   .As<Profile>();
        }
    }
}
