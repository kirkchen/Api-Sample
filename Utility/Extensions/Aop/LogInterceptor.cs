using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;

namespace ApiSample.Utility.Extensions.Aop
{
    public class LogInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }

        public LogInterceptor(ILogger logger)
        {
            this.Logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {

            this.Logger.Debug("呼叫方法:{0}, 參數:{1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            this.Logger.Debug("執行結果:{0}.", invocation.ReturnValue);
        }
    }
}
