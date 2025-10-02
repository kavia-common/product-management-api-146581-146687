# Products Backend (Ocean Professional)

A modern, minimal REST API for managing products.

- Language/Framework: .NET 8 Minimal APIs
- Theme: Ocean Professional (Blue & amber accents)

Base URL:
- http://localhost:3001

Docs (Swagger/NSwag):
- http://localhost:3001/docs

Endpoints:
- GET /api/products/ — list products
- GET /api/products/{id} — get a product
- POST /api/products/ — create product
- PUT /api/products/{id} — update product
- DELETE /api/products/{id} — delete product

Models:
- Product: { id: Guid, name: string, price: decimal, quantity: int }
- CreateProductRequest: { name, price, quantity }
- UpdateProductRequest: { name, price, quantity }

Notes:
- Uses an in-memory repository for now. Swap IProductRepository implementation for a database later.
