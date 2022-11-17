using ClassLibrary.Entity;
using ClassLibrary.Repository.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Examples.DesignPatterns.Decorator
{
    public class ListSerializer : IProductSerializer
    {
        private IProductSerializer productSerializer;

        public ListSerializer(IProductSerializer productSerializer)
        {
            this.productSerializer = productSerializer;
        }
        public HashSet<Product> ReadProducts()
        {
            return productSerializer.ReadProducts();
        }

        public void WriteProducts(HashSet<Product> products)
        {
            productSerializer.WriteProducts(products);
        }

        public void WriteProducts(List<Product> products)
        {
            WriteProducts(new HashSet<Product>(products));
        }

    }

    class Program
    {
        static void Main()
        {
            List<Product> products = null;
            ListSerializer serializer = new ListSerializer(new JsonProductSerializer());
            serializer.WriteProducts(products);

            FileStream fileStream = new FileStream(@"C:\Users\User\Documents\file1.bin", FileMode.Create);
            BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = { 10, 20, 127 };
            bufferedStream.Write(bytes, 0, 3);
            bufferedStream.Close();
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
