
namespace IWantApp.Endpoints.Products;

public class ProductGetShowcase
{
    public static string Template => "/products/showcase";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static IResult Action(int? page, int? row, string? orderBy, ApplicationDbContext context)
    {
        if (page == null)
            page = 1;
        if (row == null)
            row = 10;
        if (string.IsNullOrEmpty(orderBy))
            orderBy = "Placeholder";

        var queryBase = context.Products.Include(p => p.Category)
            .Where(p => p.HasStock && p.Category.IsActive);

        if (orderBy == "Placeholder")
            queryBase = queryBase.OrderBy(p => p.Name);
        else
            queryBase = queryBase.OrderBy(p => p.Price);

        var queryFilter = queryBase.Skip((page.Value - 1) * row.Value).Take(row.Value);

        var products = queryFilter.ToList();

        var results = products.Select(p => new ProductResponse(p.Name!, p.Category!.Name, p.Description!, p.HasStock, p.Price, p.IsActive));

        return Results.Ok(results);
    }
}
