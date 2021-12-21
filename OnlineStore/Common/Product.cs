using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Common
{
    public class Product
    {
        public int ProductID { get; set; }
        public int SellerID { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductRating { get; set; }
    }
}