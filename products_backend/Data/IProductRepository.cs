using ProductsBackend.Models;

namespace ProductsBackend.Data
{
    // Ocean Professional: Repository contracts are explicit and succinct.

    // PUBLIC_INTERFACE
    /// <summary>
    /// Contract for product data access.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Retrieves a product by identifier.
        /// </summary>
        Product? GetById(Guid id);

        /// <summary>
        /// Creates a new product.
        /// </summary>
        Product Create(Product product);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        bool Update(Product product);

        /// <summary>
        /// Deletes a product by identifier.
        /// </summary>
        bool Delete(Guid id);
    }
}
