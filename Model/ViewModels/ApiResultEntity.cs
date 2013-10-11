using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.ViewModels
{
    public class ApiResultEntity
    {
        public string Status { get; set; }

        public object Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
