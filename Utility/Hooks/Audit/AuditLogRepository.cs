using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.Audit
{
    public class AuditLogRepository
    {
        public IAuditableContext AuditableContext { get; set; }

        public AuditLogRepository(IAuditableContext context)
        {
            this.AuditableContext = context;
        }

        public void WriteAuditLog(Guid IdentifyKey, string IdentifyName, string originalValue, string newValue)
        {
        }
    }
}
