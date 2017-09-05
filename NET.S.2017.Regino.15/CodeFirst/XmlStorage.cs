using CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CodeFirst.Entities;

namespace CodeFirst
{
    public class XmlStorage: IProductStorage
    {
        private string _filePath;

        public XmlStorage(string filePath)
        {
            if(filePath == null)
                throw new ArgumentNullException($"{nameof(filePath)}");

            _filePath = filePath;
        }

        /// <summary>
        /// Load information about products from database.
        /// </summary>
        /// <returns>Collection of products.</returns>
        public IEnumerable<Product> Load()
        {
            using (var file = File.OpenWrite(_filePath))
            {
                var serializer = new XmlSerializer(typeof(IEnumerable<Product>));

                return (IEnumerable<Product>)serializer.Deserialize(file);
            }
        }

        /// <summary>
        /// Save information about products to database.
        /// </summary>
        /// <param name="products">Collection of products.</param>
        public void Save(IEnumerable<Product> products)
        {

            using (var file = File.OpenWrite(_filePath))
            {
                var serializer = new XmlSerializer(typeof(List<Product>));

                var productList = new List<Product>(products.Count());
                productList.AddRange(products.Select(product => new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    TypeId = product.TypeId
                }));

                serializer.Serialize(file, productList);
            }
        }
    }
}
