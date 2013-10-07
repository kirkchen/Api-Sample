using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.Audit
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class RequireAuditAttribute : Attribute
    {
        public RequireAuditAttribute()
        {
        }
    }
}
