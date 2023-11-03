using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Название книги не указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название книги должно содержать от 3 до 50 символов")]
        [NoWhitespace(ErrorMessage = "Название книги не может состоять из пробелов")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фио автора не указан")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Фио автора должно содержать от 3 до 50 символов")]
        [NoWhitespace(ErrorMessage = "Фио автора не может состоять из пробелов")]
        [JsonProperty("author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Описание книги не указано")]
        [NoWhitespace(ErrorMessage = "Описание книги не может состоять из пробелов")]
        [JsonProperty("aboutTheBook")]
        public string AboutTheBook { get; set; }

        [Required(ErrorMessage = "Описание не указано")]
        [NoWhitespace(ErrorMessage = "Поле Об авторе не может состоять из пробелов")]
        [JsonProperty("aboutAuthor")]
        public string AboutAuthor { get; set; }

        [Required(ErrorMessage = "Цитата не указана")]
        [NoWhitespace(ErrorMessage = "Цитата не может состоять из пробелов")]
        [JsonProperty("quote")]
        public string Quote { get; set; }

        [Required(ErrorMessage = "Стоимость не указана")]
        [NoWhitespace(ErrorMessage = "Стоимость не может состоять из пробелов")]
        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Описание книги не указано")]
        [NoWhitespace(ErrorMessage = "Описание книги не может состоять из пробелов")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }


        public override string ToString() => $"Product ID: {Id}\nName: {Name}\nCost: {Cost}";
    }
}

