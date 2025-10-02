using System.ComponentModel.DataAnnotations;

namespace ProductsBackend.Models
{
    // Ocean Professional: DTOs separate write contracts from domain.

    // PUBLIC_INTERFACE
    /// <summary>
    /// Payload used to create a new product.
    /// </summary>
    public class CreateProductRequest
    {
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

    // PUBLIC_INTERFACE
    /// <summary>
    /// Payload used to update an existing product.
    /// </summary>
    public class UpdateProductRequest
    {
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
