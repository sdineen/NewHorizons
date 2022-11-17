using System.Collections.Generic;
using System.IO;
using ClassLibrary.Entity;
using System.Text.Json;

namespace ClassLibrary.Repository.JSON
{
    public class JsonProductSerializer : IProductSerializer
    {
        private string path = @"C:\Users\Public\Documents\products.json";

        public void WriteProducts(HashSet<Product> products)
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(path, json);
        }

        public HashSet<Product> ReadProducts()
        {
            if(!File.Exists(path))
            {
                return null;
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<HashSet<Product>>(json);
        }
    }
}
