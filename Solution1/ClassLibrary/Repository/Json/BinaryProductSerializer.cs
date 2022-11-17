using System.Collections.Generic;
using System.IO;
using ClassLibrary.Entity;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary.Repository.JSON
{
    public class BinaryProductSerializer : IProductSerializer
    {
        private string path = @"C:\Users\Public\Documents\products.bin";

        public void WriteProducts(HashSet<Product> products)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, products);
        }

        public HashSet<Product> ReadProducts()
        {
            if (!File.Exists(path))
            {
                return null;
            }
            using Stream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            return (HashSet<Product>)formatter.Deserialize(stream);
        }
    }
}
