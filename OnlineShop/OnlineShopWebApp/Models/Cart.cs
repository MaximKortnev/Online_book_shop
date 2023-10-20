using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Cost { get => Items?.Sum(prod => prod.Cost) ?? 0; }
        public decimal Amount { get => Items?.Sum(prod => prod.Amount) ?? 0; }
    }
}
