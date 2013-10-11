using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSample.Models
{
    public class ProductForCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime StartListingAt { get; set; }

        public DateTime FinishListingAt { get; set; }
    }
}
