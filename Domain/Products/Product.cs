namespace IWantApp.Domain.Products;

public class Product : Entity
{
    public required Category category { get; set; }
    public required Guid CategoryId { get; set; }
    public required string Description { get; set; }
    public required bool HasStock { get; set; }
    public bool isActive { get; set; } = true;

}
