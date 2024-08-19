namespace IWantApp.Endpoints.Categories;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required bool Active { get; set; }
};