using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.Audit
{
    public interface IAuditableContext
    {
        IDbSet<AuditLog> AuditLogs { get; set; }
    }
}
