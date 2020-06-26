using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApplication.Models
{
  public class Store
    {

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public List<Product> ProductDetails { get; set; }


    }
}
