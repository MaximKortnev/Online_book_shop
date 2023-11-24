﻿namespace OnlineShop_WebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get => Product.Cost * Amount; }
    }
}
