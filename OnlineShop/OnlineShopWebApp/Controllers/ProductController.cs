﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> ReadProductsFromJson(string filePath)
        {
            string json;

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Product>>(json);
        }
        public string Index(int id = -1)
        {
            string jsonFilePath = "data.json";
            List<Product> products = ReadProductsFromJson(jsonFilePath);

            string result_str = "";
            foreach (var product in products)
                {
                    if (product.Id == id)
                    {
                        result_str = "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\nDescription: " + product.Description;
                        break;
                    }
                    else { result_str = "Такого товара нет"; }
                }
            if (id == -1) { result_str = "Вы не выбрали товар"; }
            return result_str;
        }
    }
}
