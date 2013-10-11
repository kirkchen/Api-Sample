using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiSample.Utility.Extensions
{
    public class ModelValidatorFactory : ValidatorFactoryBase
    {        
        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = DependencyResolver.Current.GetService(validatorType) as IValidator;

            return validator;
        }
    }
}
