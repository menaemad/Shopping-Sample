using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingStoreSample.ViewModel
{
    public class AllOrders
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }


    }
}