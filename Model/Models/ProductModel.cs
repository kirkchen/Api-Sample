using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSample.Models
{
    public class ProductModel
    {        
        public int Id { get; set; }
     
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Cost { get; set; }
        
        public string Description { get; set; }

        public DateTime ListingStartTime { get; set; }

        public DateTime ListingEndTime { get; set; }

        public DateTime SellingStartTime { get; set; }

        public DateTime SellingEndTime { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<GiftModel> Gifts { get; set; }
    }
}
