using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Entities
{
    /// <summary>
    /// Represents product and information about it.
    ///</summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// Id of product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of a product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of a product.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Represents an image.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Description of a current product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id of a type.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Type of a product.
        /// </summary>
        public virtual ProductType Type { get; set; }
    }
}
