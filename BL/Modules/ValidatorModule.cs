using ApiSample.BL.Validators;
using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.ViewModels;
using System.Reflection;

namespace ApiSample.BL.Modules
{
    public class ValidatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            var mappings = Assembly.Load("ApiSample.BL.Validators");                        

            builder.RegisterAssemblyTypes(mappings)
                   .Where(i => i.Name.EndsWith("Validator"))
                   .As(i => typeof(IValidator<>).MakeGenericType(i.BaseType.GetGenericArguments()));
        }
    }
}
