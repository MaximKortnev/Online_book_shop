using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Comparison
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ProductViewModel> Items { get; set; }
    }
}
