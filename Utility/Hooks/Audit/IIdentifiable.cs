using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.Audit
{
    public interface IIdentifiable
    {
        Guid IdentifyKey { get; set; }
    }
}
