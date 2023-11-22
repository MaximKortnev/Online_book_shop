using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ProductViewModel> Items { get; set; }
        public decimal Cost { get => Items.Sum(prod => prod.Cost); }
    }
}
