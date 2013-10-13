using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiSample.Utility.Extensions.Authentication
{
    public class ApiModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue("data");

            if (valueResult != null &&
                !string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
            {
                try
                {
                    var data = valueResult.AttemptedValue;
                    var modelType = bindingContext.ModelType;
                    var model = JsonConvert.DeserializeObject(data, modelType);

                    ModelBindingContext newBindingContext = new ModelBindingContext()
                    {
                        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                            () => model,
                            modelType
                        ),
                        ModelState = bindingContext.ModelState,
                        ValueProvider = bindingContext.ValueProvider
                    };

                    return base.BindModel(controllerContext, newBindingContext);
                }
                catch
                {
                    //// Skip json.net deserialize error
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
