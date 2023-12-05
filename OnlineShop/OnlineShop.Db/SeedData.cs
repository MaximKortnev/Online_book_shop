﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Приключения Буратино",
                        Author = "Алексей Толстой",
                        AboutTheBook = "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.",
                        AboutAuthor = "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.",
                        Quote = "Считаю до трёх, а потом как дам больно!",
                        Cost = (decimal)20.00,
                        Description = "Невероятная история о деревянном мальчике",
                        ImagePath = "image.jpg",
                        ImagePaths = ["image.jpg", "image.jpg", "image.jpg"]
                    },
                    new Product
                    {
                        Name = "Алиса в стране чудес",
                        Author = "Льюис Кэрролл",
                        AboutTheBook = "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.",
                        AboutAuthor = "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.",
                        Quote = "Считаю до трёх, а потом как дам больно!",
                        Cost = (decimal)15.99,
                        Description = "Книга о приключениях девочки Асилы и о неведомых чудесах созданных Льюисом Кэрроллом ",
                        ImagePath = "image.jpg",
                        ImagePaths = ["image.jpg", "image.jpg", "image.jpg"]
                    },
                    new Product
                    {
                        Name = "Марта",
                        Author = "Аполина Андреевна",
                        AboutTheBook = "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.",
                        AboutAuthor = "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.",
                        Quote = "Считаю до трёх, а потом как дам больно!",
                        Cost = (decimal)15.00,
                        Description = "Биографическая книга о мыслях и жизни девушки по имени Марта",
                        ImagePath = "image.jpg",
                        ImagePaths = ["image.jpg", "image.jpg", "image.jpg"]
                    },
                    new Product
                    {
                        Name = "Жан Пьер Мюри. Автобиография",
                        Author = "Жан Пьер Мюри",
                        AboutTheBook = "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.",
                        AboutAuthor = "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.",
                        Quote = "Считаю до трёх, а потом как дам больно!",
                        Cost = (decimal)45.20,
                        Description = "Жан Пьер Мюри, одна из выдающихся личностей прошлого столетия",
                        ImagePath = "image.jpg",
                        ImagePaths = ["image.jpg", "image.jpg", "image.jpg"]
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
