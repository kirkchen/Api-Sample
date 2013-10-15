using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.ViewModels
{
    [Serializable]
    public class AuthorizeTokenFailureException : Exception
    {
        public AuthorizeTokenFailureException() { }
        public AuthorizeTokenFailureException(string message) : base(message) { }
        public AuthorizeTokenFailureException(string message, Exception inner) : base(message, inner) { }
        protected AuthorizeTokenFailureException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
