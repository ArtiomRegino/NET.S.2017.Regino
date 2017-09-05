using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using CodeFirst.Interfaces;

namespace CodeFirst.Servicies
{
    /// <summary>
    /// Service for Shop database.
    /// </summary>
    public class ShopService
    {
        private readonly ShopContext _db;

        /// <summary> 
        /// Constructor.
        /// </summary>
        /// <param name="db">ShopContext to work with database.</param>
        public ShopService(ShopContext db)
        {
            if (db != null) _db = db;
        }

        /// <summary>
        /// Returns all products from database.
        /// </summary>
        /// <returns>Collection of products.</returns>
        public IEnumerable<Product> GetProducts() => _db.Products.AsEnumerable();

        /// <summary>
        /// Returns all types of products
        /// </summary>
        /// <returns>Types of products.</returns>
        public IEnumerable<ProductType> GetProductTypes() => _db.ProductTypes.AsEnumerable();

        /// <summary>
        /// Add product to a database.
        /// </summary>
        /// <param name="product">Product to add.</param>
        /// <exception cref="ArgumentNullException">Throws when product is null.</exception>
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            _db.Products.Add(product);
            _db.SaveChanges();
        }

        /// <summary>
        /// Remove product from a database.      
        /// </summary>
        /// <param name="product">Product to remove.</param>
        /// <exception cref="ArgumentNullException">Throws when product is null.</exception>
        public void RemoveProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        /// <summary>
        /// Remove product at position.
        /// </summary>
        /// <param name="id">Id of product to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when id less than 0.</exception>
        public void RemoveProduct(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException($"{nameof(id)}");

            _db.Products.Remove(_db.Products.ElementAt(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// Changes price of product.
        /// </summary>
        /// <param name="id">Id of product to change.</param>
        /// <param name="price">New price of product.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when id less than 0.</exception>
        public void ChangePrice(int id, float price)
        {
            if (id < 0) throw new ArgumentOutOfRangeException($"{nameof(price)}");

            _db.Products.ElementAt(id).Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Save(IProductStorage storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            storage.Save(_db.Products.AsEnumerable());
        }
    }
}
