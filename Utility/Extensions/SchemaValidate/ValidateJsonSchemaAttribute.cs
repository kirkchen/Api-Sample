using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ApiSample.Utility.Extensions.SchemaValidate
{
    public class ValidateJsonSchemaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var parameterDescriptors = filterContext.ActionDescriptor.GetParameters();

            //// Get json data
            var rawValue = filterContext.Controller.ValueProvider.GetValue("data");
            var rawData = string.Empty;
            if (rawValue == null)
            {
                return;
            }
            else
            {
                rawData = rawValue.AttemptedValue;
            }

            //// Check Parameter type
            if (parameterDescriptors.Count() != 1 || parameterDescriptors.First().ParameterType.IsValueType)
            {
                return;
            }

            //// Get json schema from parameter
            JsonSchema jsonSchema = null;
            var parameterDescriptor = parameterDescriptors.First();
            var jsonSchemaGenerator = new JsonSchemaGenerator();
            jsonSchema = jsonSchemaGenerator.Generate(parameterDescriptor.ParameterType);
            jsonSchema.Title = parameterDescriptor.ParameterType.Name;

            jsonSchema = JsonSchema.Parse(jsonSchema.ToString().ToLower());

            var errs = new List<string>() as IList<string>;
            JObject jsonObject = null;

            //// 處理Json格式的異常
            try
            {
                jsonObject = JObject.Parse(rawData.ToLower());
            }
            catch (JsonReaderException ex)
            {
                throw new JsonSchemaNotValidException(ex.Message, ex);
            }

            var valid = jsonObject.IsValid(jsonSchema, out errs);
            if (errs.Count > 0)
            {
                throw new JsonSchemaNotValidException("請確認傳入資料型別是否符合規範!" + 
                    string.Join(",", errs.ToArray()));
            }
        }
    }
}
