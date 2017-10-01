using System.Collections.Generic;

namespace BLL.Interfaces.Interfaces
{
    public interface IService<T>
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
