using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Modules
{
        public class MappingModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {            
                var mappings = Assembly.Load("ApiSample.BL.Mappings");

                builder.RegisterAssemblyTypes(mappings)
                       .Where(i => i.Name.EndsWith("MappingProfile"))
                       .As(i => i.BaseType);
            }
        }
}
