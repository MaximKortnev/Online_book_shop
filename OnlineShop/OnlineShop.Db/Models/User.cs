using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string NickName { get; set; }
        public string AvatarImagePath { get; set; }
    }
}
