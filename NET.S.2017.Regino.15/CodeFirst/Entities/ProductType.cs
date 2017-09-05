using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Entities
{
    /// <summary>
    /// Represents type of a product.
    /// </summary>
    [Table("ProductType")]
    public class ProductType
    {
        /// <summary>
        /// Id of a type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of a type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of products of current a type.
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }
}
