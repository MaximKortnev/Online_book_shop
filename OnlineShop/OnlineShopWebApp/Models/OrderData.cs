namespace OnlineShopWebApp.Models
{
    public class OrderData
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DeliveryMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string PromoCode { get; set; }
        public string TotalCost { get; set; }
        public string ListProducts { get; set; }
    }
}
