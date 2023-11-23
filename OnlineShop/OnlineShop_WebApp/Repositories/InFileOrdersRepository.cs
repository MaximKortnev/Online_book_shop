using Newtonsoft.Json;
using OnlineShop_WebApp.Models;
using OnlineShop_WebApp.Interfaces;

namespace OnlineShop_WebApp.Repositories
{
    public class InFileOrdersRepository : IOrdersRepository
    {
        public List<Order> orders = new List<Order>();

        public void Add(Cart cart, string userId)
        {
            var newOrder = new Order()
            {
                UserId = userId,
                ListProducts = cart,
            };
            orders.Add(newOrder);
        }
        public void SaveOrders(Order orderData, string userId, Cart cart)
        {
            string filePath = "wwwroot/orders.json";
            var order = TryGetByUserId(Constants.UserId);
            orderData.Id = Guid.NewGuid();
            orderData.ListProducts = order.ListProducts;
            orderData.UserId = order.UserId;
            orderData.Status = OrderStatus.Created;
            orderData.Data = DateTime.Now;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var existingOrders = JsonConvert.DeserializeObject<List<Order>>(json);
                if (existingOrders == null)
                {
                    existingOrders = new List<Order>
                    {
                        orderData
                    };
                }
                existingOrders.Add(orderData);
                string updatedJson = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
        public Order TryGetByUserId(string userId) => orders.FirstOrDefault(x => x.UserId == userId);
        public Order TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);

        private List<Order> ReadOrdersFromJson(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Order>>(json);
        }

        public List<Order> GetAll()
        {
            var jsonFilePath = "wwwroot/orders.json";
            return File.Exists(jsonFilePath) ? ReadOrdersFromJson(jsonFilePath) : new List<Order> { };
        }
    }
}
