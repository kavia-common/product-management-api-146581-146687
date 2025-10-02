using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsBackend.Data;
using ProductsBackend.Models;

namespace ProductsBackend.Endpoints
{
    // Ocean Professional: Endpoint definitions grouped by resource, predictable paths.

    // PUBLIC_INTERFACE
    /// <summary>
    /// Extension methods to register Product REST endpoints.
    /// </summary>
    public static class ProductEndpoints
    {
        // PUBLIC_INTERFACE
        /// <summary>
        /// Maps CRUD endpoints for products.
        /// </summary>
        /// <param name="app">The web application.</param>
        /// <returns>The web application.</returns>
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products")
                           .WithTags("Products");

            // List
            group.MapGet("/", ([FromServices] IProductRepository repo)
                => Results.Ok(repo.GetAll()))
            .WithSummary("List products")
            .WithDescription("Returns a collection of all available products.")
            .Produces<IEnumerable<Product>>(StatusCodes.Status200OK);

            // Get by id
            group.MapGet("/{id:guid}", ([FromRoute] Guid id, [FromServices] IProductRepository repo)
                => repo.GetById(id) is Product p
                    ? Results.Ok(p)
                    : Results.NotFound(new { message = "Product not found." }))
            .WithSummary("Get product by id")
            .WithDescription("Retrieves a single product by its unique identifier.")
            .Produces<Product>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // Create
            group.MapPost("/", ([FromBody] CreateProductRequest request, [FromServices] IProductRepository repo)
                => request is null
                    ? Results.BadRequest(new { message = "Invalid payload." })
                    : Results.Created($"/api/products/{repo.Create(new Product
                    {
                        Name = request.Name.Trim(),
                        Price = request.Price,
                        Quantity = request.Quantity
                    }).Id}", repo.GetAll().Last()))
            .WithSummary("Create product")
            .WithDescription("Creates a new product using the provided payload.")
            .Produces<Product>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            // Update
            group.MapPut("/{id:guid}", ([FromRoute] Guid id, [FromBody] UpdateProductRequest request, [FromServices] IProductRepository repo)
                =>
            {
                var existing = repo.GetById(id);
                if (existing is null)
                {
                    return Results.NotFound(new { message = "Product not found." });
                }

                existing.Name = request.Name.Trim();
                existing.Price = request.Price;
                existing.Quantity = request.Quantity;

                if (!repo.Update(existing))
                {
                    return Results.Problem("Failed to update product.", statusCode: StatusCodes.Status500InternalServerError);
                }

                return Results.Ok(existing);
            })
            .WithSummary("Update product")
            .WithDescription("Updates an existing product identified by id.")
            .Produces<Product>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

            // Delete
            group.MapDelete("/{id:guid}", ([FromRoute] Guid id, [FromServices] IProductRepository repo)
                => repo.Delete(id)
                    ? Results.NoContent()
                    : Results.NotFound(new { message = "Product not found." }))
            .WithSummary("Delete product")
            .WithDescription("Deletes a product identified by id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

            return app;
        }
    }
}
