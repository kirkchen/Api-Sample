using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.ViewModels
{
    public class ApiRequestEntity
    {
        public string Token { get; set; }

        public string TimeStamp { get; set; }

        public string Signature { get; set; }

        public string Data { get; set; }
    }
}
