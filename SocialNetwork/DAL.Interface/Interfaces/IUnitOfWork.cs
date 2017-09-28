using System;

namespace DAL.Interface.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
