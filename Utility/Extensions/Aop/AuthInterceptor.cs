using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.Aop
{
    public class AuthInterceptor : IInterceptor
    {
        private string role;

        public AuthInterceptor(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException("role");
            }

            this.role = role;
        }

        public void Intercept(IInvocation invocation)
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated ||
                !Thread.CurrentPrincipal.IsInRole(this.role))
            {
                throw new UnauthorizedAccessException();
            }

            invocation.Proceed();
        }
    }
}
