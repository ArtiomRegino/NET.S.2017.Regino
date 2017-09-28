using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? key);
        void Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity e);
    }
}
