using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.Authentication
{
    public interface IEncryptHelper
    {
        string Encrypt(string key, string source);
    }
}
