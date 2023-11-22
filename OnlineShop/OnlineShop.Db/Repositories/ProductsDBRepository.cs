using OnlineShop.Db.Models;
using OnlineShop.Db.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class ProductsDBRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDBRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        //public List<Product> ReadProductsFromJson(string filePath)
        //{
        //    var json = "";

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        json = reader.ReadToEnd();
        //    }
        //    return JsonConvert.DeserializeObject<List<Product>>(json);
        //}
        public Product TryGetProductById(Guid id) => databaseContext.Products.FirstOrDefault(p => p.Id == id);

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Add(Product product)
        {
            product.ImagePath = "image.jpg";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        public void Edit(Product product)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x=> x.Id == product.Id);
            if (existingProduct == null) { return; }
            existingProduct = product;
            existingProduct.ImagePath = "image.jpg";
            databaseContext.SaveChanges();
        }
    }
}
