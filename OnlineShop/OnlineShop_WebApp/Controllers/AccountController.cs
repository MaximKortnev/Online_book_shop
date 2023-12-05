using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop_WebApp.Mappings;
using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOrdersRepository orderRepository;
        private readonly UserManager<User> usersManager;
        private readonly IWebHostEnvironment appEnvironment;
        public AccountController(IOrdersRepository orderRepository, UserManager<User> usersManager, IWebHostEnvironment appEnvironment)
        {
            this.orderRepository = orderRepository;
            this.usersManager = usersManager;
            this.appEnvironment = appEnvironment;
        }



        public IActionResult Main()
        {
            return View();
        }

        public IActionResult GetOptions()
        {
            var user = usersManager.FindByNameAsync(User.Identity.Name).Result;
            if (user == null) { return View("ExistUser"); }
            return View(user.ToUserViewModel());
        }

        public IActionResult GetOrders()
        {
            var orders = orderRepository.GetAllByUser(User.Identity.Name);
            if (orders == null) { return View(); }
            var ordersViewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                ordersViewModel.Add(Mapping.ToOrderViewModel(order));
            }
            return View(ordersViewModel);
        }

        public IActionResult EditAvatar(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            if (user == null) { return View("ExistUser"); }
            return View(new UserEditAvatarViewModel { 
                Login = user.UserName,
                AvatarImagePath = user.AvatarImagePath
            });
        }

        [HttpPost]
        public IActionResult SaveEditAvatar(UserEditAvatarViewModel userView)
        {
            var user = usersManager.FindByNameAsync(userView.Login).Result;
            if (user == null) { return View("ExistUser"); }
            if (userView.UploadNewAvatar != null)
            {
                string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/images/users/");
                if (!Directory.Exists(productImagesPath))
                {
                    Directory.CreateDirectory(productImagesPath);
                }

                var filename = Guid.NewGuid() + "." + userView.UploadNewAvatar.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagesPath + filename, FileMode.Create))
                {
                    userView.UploadNewAvatar.CopyTo(fileStream);
                }
                user.AvatarImagePath = "/images/users/" + filename;
                usersManager.UpdateAsync(user).Wait();
            }
            return RedirectToAction("Main");
        }

    }
}
