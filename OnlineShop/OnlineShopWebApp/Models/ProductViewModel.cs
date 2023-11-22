using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Имя не указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 50 символов")]
        [NoWhitespace(ErrorMessage = "Имя не может состоять из пробелов")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Автор не указан")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Поле должно содержать от 3 до 50 символов")]
        [NoWhitespace(ErrorMessage = "Автор не может состоять из пробелов")]
        [JsonProperty("author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Описание не указано")]
        [NoWhitespace(ErrorMessage = "Описание не может состоять из пробелов")]
        [JsonProperty("aboutTheBook")]
        public string AboutTheBook { get; set; }

        [Required(ErrorMessage = "Описание не указано")]
        [NoWhitespace(ErrorMessage = "Описание не может состоять из пробелов")]
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

        [Required(ErrorMessage = "Описание не указано")]
        [NoWhitespace(ErrorMessage = "Описание не может состоять из пробелов")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }
    }
}

