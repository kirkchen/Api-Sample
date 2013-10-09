using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.ViewModels
{
    public class InsertProductModel
    {        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public string Introduction { get; set; }

        public DateTime StartListingAt { get; set; }

        public DateTime FinishListingAt { get; set; }

        public DateTime StartSellAt { get; set; }

        public DateTime FinishSellAt { get; set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// This is not good design, just for example
        /// </summary>
        public string Gifts { get; set; }
    }
}
