using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Models
{
    public class GiftModel
    {        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}
