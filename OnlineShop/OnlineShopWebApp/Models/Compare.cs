using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Compare
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; }
    }
}
