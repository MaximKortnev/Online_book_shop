using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IProductsRepository
    {
        Product TryGetProductById(Guid productId);
        List<Product> GetAll();
        void Add(Product product);
    }
}
