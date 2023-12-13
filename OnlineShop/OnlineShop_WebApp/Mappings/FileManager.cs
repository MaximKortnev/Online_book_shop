using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Mappings
{
    public static class FileManager
    {

        public static List<string> SaveProductImagesInDB(ProductViewModel product, IWebHostEnvironment appEnvironment)
        {
            string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
            if (!Directory.Exists(productImagesPath))
            {
                Directory.CreateDirectory(productImagesPath);
            }
            var imagePaths = new List<string>();

            foreach (var imageFile in product.ImageFiles)
            {
                var filename = Guid.NewGuid() + "." + imageFile.FileName.Split('.').Last();
                var filePath = Path.Combine(productImagesPath, filename);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                imagePaths.Add("/images/products/" + filename);
            }

            return imagePaths;
        }
    }
}
