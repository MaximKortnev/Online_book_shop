using OnlineShop.Db.Models;
using OnlineShop.Db.Interfaces;


namespace OnlineShop.Db.Repositories
{
    public class FavoritesDBRepository : IFavoritesRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavoritesDBRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite == null)
            {
                var newCompare = new Favorite()
                {
                    UserId = userId,
                    Items = new List<Product> { product }
                };
                databaseContext.Favorites.Add(newCompare);
            }
            else if (existingFavorite.Items.FirstOrDefault(prod => prod.Id == product.Id) == null)
            {
                existingFavorite.Items.Add(product);
            }
            databaseContext.SaveChanges();
        }

        public void Decrease(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite != null)
            {
                var existingCardItem = existingFavorite.Items.FirstOrDefault(prod => prod != null && prod.Id == product.Id);

                if (existingCardItem != null) existingFavorite.Items.Remove(existingCardItem);
                if (existingFavorite.Items.Count == 0) Clear(userId);
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingFavorites = TryGetByUserId(userId);
            if (existingFavorites != null)
            {
                databaseContext.Favorites.Remove(existingFavorites);
                databaseContext.SaveChanges();
            }
        }

        public Favorite TryGetByUserId(string userId) => databaseContext.Favorites.FirstOrDefault(x => x.UserId == userId);
    }
};