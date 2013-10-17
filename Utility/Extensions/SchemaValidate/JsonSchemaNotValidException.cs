using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.SchemaValidate
{
    [Serializable]
    public class JsonSchemaNotValidException : Exception
    {
        public JsonSchemaNotValidException() { }
        public JsonSchemaNotValidException(string message) : base(message) { }
        public JsonSchemaNotValidException(string message, Exception inner) : base(message, inner) { }
        protected JsonSchemaNotValidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
