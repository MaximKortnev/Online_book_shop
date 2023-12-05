﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AboutAuthor", "AboutTheBook", "Author", "Cost", "Description", "ImagePath", "Name", "Quote" },
                values: new object[,]
                {
                    { new Guid("3909f89f-504d-47e4-bb46-3b075eeb965a"), "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.", "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.", "Льюис Кэрролл", 15.99m, "Книга о приключениях девочки Асилы и о неведомых чудесах созданных Льюисом Кэрроллом ", "image.jpg", "Алиса в стране чудес", "Считаю до трёх, а потом как дам больно!" },
                    { new Guid("54f156c8-7811-48e9-ab1c-de91ec833d00"), "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.", "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.", "Аполина Андреевна", 15m, "Биографическая книга о мыслях и жизни девушки по имени Марта", "image.jpg", "Марта", "Считаю до трёх, а потом как дам больно!" },
                    { new Guid("5e4c17f8-ac59-4e75-a249-d9bc8109b0c6"), "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.", "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.", "Алексей Толстой", 20m, "Невероятная история о деревянном мальчике", "image.jpg", "Приключения Буратино", "Считаю до трёх, а потом как дам больно!" },
                    { new Guid("c79ea32e-2163-47ff-a489-d72f07a02191"), "Толстой Алексей Николаевич – прозаик, поэт. Родился 29 декабря 1882 года в городе Николаевске Самарской губернии. После окончания реального училища в Самаре поступил на отделение механики Технологического института, но незадолго до окончания бросает его, окончательно решив посвятить себя литературному труду.", "Озорной мальчишка с длинным носом, Буратино, на протяжении 85 лет вновь и вновь зовёт детей отправиться в сказочное приключение. Вы побываете в Стране Дураков вместе с котом Базилио и лисой Алисой, погостите у прекрасной Мальвины, познакомитесь с черепахой Тортилой, перехитрите ужасного Карабаса Барабаса, и конечно же, раскроете тайну Золотого Ключика.", "Жан Пьер Мюри", 45.2m, "Жан Пьер Мюри, одна из выдающихся личностей прошлого столетия", "image.jpg", "Жан Пьер Мюри. Автобиография", "Считаю до трёх, а потом как дам больно!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3909f89f-504d-47e4-bb46-3b075eeb965a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54f156c8-7811-48e9-ab1c-de91ec833d00"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e4c17f8-ac59-4e75-a249-d9bc8109b0c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c79ea32e-2163-47ff-a489-d72f07a02191"));
        }
    }
}