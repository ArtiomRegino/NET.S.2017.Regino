using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout role class.
    /// </summary>
    public class DalRole : IEntity
    {
        /// <summary>
        /// DalRole id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalRole name.
        /// </summary>
        public string Name { get; set; }
    }
}
