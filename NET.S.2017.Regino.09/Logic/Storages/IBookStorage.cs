using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Storages
{
    interface IBookStorage
    {
        void Save(IEnumerable<Book> books);
        IEnumerable<Book> Read();
    }
}
