using ApiSample.Utility.Extensions;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite
{
    public class FluentValidationConfig
    {
        public static void Initialize()
        {
            var container = AutofacDependencyResolver.Current.ApplicationContainer as IContainer;

            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new ModelValidatorFactory());
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
        }
    }
}