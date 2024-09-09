
namespace IWantApp.Endpoints.Products;

public class ProductGetShowcase
{
    public static string Template => "/products/showcase";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static IResult Action(ApplicationDbContext context)
    {
        var products = context.Products.Include(p => p.Category).Where(p => p.HasStock && p.Category!.IsActive).OrderBy(p => p.Name).ToList();

        var results = products.Select(p => new ProductResponse(p.Name!, p.Category!.Name, p.Description!, p.HasStock, p.Price, p.IsActive));

        return Results.Ok(results);
    }
}
