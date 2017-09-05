using System;
using System.Linq;
using CodeFirst.Entities;
using CodeFirst.Servicies;

namespace CodeFirst.Tests
{
    class Program
    {
        static void Main()
        {
            using (var db = new ShopContext())
            {
                string[] names = { "Books", "Food", "Furniture", "Clothes"  };
                foreach (string str in names)
                {
                    if (!db.ProductTypes.Any() || db.ProductTypes.FirstOrDefault((item) => item.Name == str) == null)
                        db.ProductTypes.Add(new ProductType() { Name = str });
                }

                db.SaveChanges();
                string[] productNames = { "Catcher in the rye", "Banana", "Table", "Shirt"  };
                for (int i = 0; i < productNames.Length; i++)
                {
                    var typeName = names[i];
                    var productName = productNames[i];
                    if (db.Products.Count() != 0 && db.Products.FirstOrDefault((item) => item.Name == productName) != null)
                        continue;

                    db.Products.Add(new Product()
                    {
                        Name = productName,
                        Type = db.ProductTypes.First((item) => item.Name == typeName)
                    });
                }
                db.SaveChanges();

                if (!db.Purchases.Any())
                    db.Purchases.Add(new Purchase());
                db.SaveChanges();

                if (db.Orders.FirstOrDefault((item) => item.Product.Name == "Shirt") == null)
                    db.Orders.Add(new Order()
                    {
                        Product = db.Products.First((item) => item.Name == "Shirt"),
                        Count = 5,
                        Purchase = db.Purchases.First()
                    });
                if (db.Orders.FirstOrDefault((item) => item.Product.Name == "Banana") == null)
                    db.Orders.Add(new Order()
                    {
                        Product = db.Products.First((item) => item.Name == "Banana"),
                        Count = 10,
                        Purchase = db.Purchases.First()
                    });
                db.SaveChanges();

                Console.WriteLine("Product types: ");
                var productTypes = from item in db.ProductTypes select item.Name;
                foreach (var i in productTypes) Console.WriteLine(i);

                Console.WriteLine(string.Format(Environment.NewLine + "Products:"));
                var products = from item in db.Products select new {item.Name, Type = item.Type.Name };
                foreach (var i in products) Console.WriteLine(i.Name.Trim() + ' ' + i.Type.Trim());

                Console.WriteLine(string.Format(Environment.NewLine + "Orders:"));
                var lots = from item in db.Orders select new { Product = item.Product.Name, item.Count };
                foreach (var i in lots) Console.WriteLine(i.Product.Trim() + ' ' + i.Count);

                var service = new ShopService(db);
                service.Save(new XmlStorage("Products.xml"));
            }

            Console.ReadKey();
        }
    }
}
