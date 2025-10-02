using System.ComponentModel.DataAnnotations;

namespace ProductsBackend.Models
{
    // Ocean Professional: Domain model – minimal, readable, and precise.
    // PUBLIC_INTERFACE
    /// <summary>
    /// Represents a product entity in the system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier of the product.
        /// </summary>
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Display name of the product.
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        /// <summary>
        /// Available inventory count.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
