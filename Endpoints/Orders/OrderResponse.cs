namespace IWantApp.Endpoints.Orders;

public record OrderResponse(Guid ProductId, string ClientEmail, string DeliveryAddress, IEnumerable<OrderProduct> Products);

public record OrderProduct(Guid id, string Name);