using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Entities
{
    /// <summary>
    /// Represent order.
    /// </summary>
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// Id of an order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Quantity of a product.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Product an id. 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product in an order.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Purchasean  id.
        /// </summary>
        public int PurchaseId { get; set; }

        /// <summary>
        /// Purchase that includes an order.
        /// </summary>
        public virtual Purchase Purchase { get; set; }
    }
}
