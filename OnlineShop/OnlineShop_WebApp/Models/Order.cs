using System.ComponentModel.DataAnnotations;

namespace OnlineShop_WebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Укажите ФИО")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "ФИО должно содержать от 5 до 40 символов")]
        [NoWhitespace(ErrorMessage = "Имя не может состоять из пробелов")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Укажите Адрес")]
        [NoWhitespace(ErrorMessage = "Имя не может состоять из пробелов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите Телефон")]
        [NoWhitespace(ErrorMessage = "Имя не может состоять из пробелов")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Указан не валидный e-mail")]
        public string Email { get; set; }
        public string DeliveryMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string? PromoCode { get; set; }
        public string TotalCost { get; set; }
        public CartViewModel? ListProducts { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Data { get; set; }
    }
}
