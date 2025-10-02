using ProductsBackend.Models;

namespace ProductsBackend.Data
{
    // Ocean Professional: In-memory storage for development and testing.

    /// <summary>
    /// In-memory repository implementation for products.
    /// </summary>
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _store = new();

        public InMemoryProductRepository()
        {
            // Seed with sample data to improve DX and quick validation.
            var sample = new[]
            {
                new Product { Name = "Ocean Notebook", Price = 9.99m, Quantity = 120 },
                new Product { Name = "Amber Pen", Price = 2.49m, Quantity = 500 },
                new Product { Name = "Blue Mug", Price = 12.00m, Quantity = 75 },
            };
            foreach (var p in sample)
            {
                _store[p.Id] = p;
            }
        }

        public Product Create(Product product)
        {
            _store[product.Id] = product;
            return product;
        }

        public bool Delete(Guid id) => _store.Remove(id);

        public IEnumerable<Product> GetAll() => _store.Values.OrderBy(p => p.Name);

        public Product? GetById(Guid id) => _store.TryGetValue(id, out var p) ? p : null;

        public bool Update(Product product)
        {
            if (!_store.ContainsKey(product.Id)) return false;
            _store[product.Id] = product;
            return true;
        }
    }
}
