using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Token { get; set; }

        public string EncryptKey { get; set; }

        public string SaltKey { get; set; }

        public IEnumerable<string> Groups { get; set; }
    }
}
