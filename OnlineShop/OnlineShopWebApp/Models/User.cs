using System;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
