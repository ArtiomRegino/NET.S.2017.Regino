using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Entities
{
    /// <summary>
    /// Represents purchase.
    /// </summary>
    [Table("Purchase")]
    public class Purchase
    {
        /// <summary>
        /// Id of an purchase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of orders current purchase consits of.
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
