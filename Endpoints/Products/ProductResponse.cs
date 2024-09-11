namespace IWantApp.Endpoints.Products;

public record ProductResponse(Guid id, string Name, string CategoryName, string Description, bool HasStock, decimal price, bool Active);
