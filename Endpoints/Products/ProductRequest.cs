namespace IWantApp.Endpoints.Products;

public record ProductRequest(Guid CategoryId, string Name, string Description, decimal price, bool HasStock, bool Active);
