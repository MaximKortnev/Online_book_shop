using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderData
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Укажите ФИО")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "ФИО должно содержать от 5 до 40 символов")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Укажите Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Указан не валидный e-mail")]
        public string Email { get; set; }
        public string DeliveryMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string PromoCode { get; set; }
        public string TotalCost { get; set; }
        public Cart ListProducts { get; set; }
    }
}
