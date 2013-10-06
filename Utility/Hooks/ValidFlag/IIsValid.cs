using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.ValidFlag
{
    public interface IIsValid
    {
        bool IsValid { get; set; }
    }
}
