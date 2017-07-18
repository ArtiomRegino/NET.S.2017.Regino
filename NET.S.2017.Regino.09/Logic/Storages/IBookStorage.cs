using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Storages
{
    /// <summary>
    /// Interface to unify functionality of storagies.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Metod for saving collection in storage.
        /// </summary>
        /// <param name="books">Collection to save in storage.</param>
        void Save(IEnumerable<Book> books);

        /// <summary>
        /// Metod for reading collection from storage.
        /// </summary>
        /// <returns>Collection from storage.</returns>
        IEnumerable<Book> Read();
    }
}
