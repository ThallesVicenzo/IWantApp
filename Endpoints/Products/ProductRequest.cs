namespace IWantApp.Endpoints.Products;

public record ProductRequest(Guid CategoryId, string Name, string Description, decimal Price, bool HasStock, bool Active);
