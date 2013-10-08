using ApiSample.Utility.Hooks.UpdateSystemInfo;
using ApiSample.Utility.Hooks.ValidFlag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSample.Utility.Hooks.Audit
{
    public class AuditLog : IIdentifiable
    {
        public int Id { get; set; }

        public Guid IdentifyKey { get; set; }

        public string IdentifyName { get; set; }

        public string OriginValue { get; set; }

        public string NewValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
