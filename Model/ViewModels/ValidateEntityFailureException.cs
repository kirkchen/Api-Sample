using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.ViewModels
{
    [Serializable]
    public class ValidateEntityFailureException : Exception
    {
        public ValidateEntityFailureException() { }
        public ValidateEntityFailureException(string message) : base(message) { }
        public ValidateEntityFailureException(string message, Exception inner) : base(message, inner) { }
        protected ValidateEntityFailureException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
