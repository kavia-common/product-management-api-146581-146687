using ProductsBackend.Data;
using ProductsBackend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Ocean Professional: Service registration – clean and intentional.

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(settings =>
{
    settings.Title = "Products API";
    settings.Version = "v1";
    settings.Description = "A modern, minimal REST API for managing products.\nTheme: Ocean Professional (Blue & amber accents).";
});

// Repository (in-memory; replace with DB in future)
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

// Add validation support
builder.Services.AddProblemDetails();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
              .AllowCredentials()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Ocean Professional: Middleware pipeline – minimal, predictable.

// Use CORS
app.UseCors("AllowAll");

// Configure OpenAPI/Swagger
app.UseOpenApi();
app.UseSwaggerUi(config =>
{
    config.Path = "/docs";
    config.DocumentTitle = "Products API — Ocean Professional";
});

 // Health check endpoint
 // PUBLIC_INTERFACE
 app.MapGet("/", () => Results.Ok(new { message = "Healthy" }))
    .WithSummary("Health check")
    .WithDescription("Returns a simple health status payload.");

// Map resource endpoints
app.MapProductEndpoints();

app.Run();