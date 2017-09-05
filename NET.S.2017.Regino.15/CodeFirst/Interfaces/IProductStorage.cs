using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace CodeFirst.Interfaces
{
        public interface IProductStorage
        {
            IEnumerable<Product> Load();
            void Save(IEnumerable<Product> collection);
        }
}
