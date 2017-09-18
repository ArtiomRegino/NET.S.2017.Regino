using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface IService<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
