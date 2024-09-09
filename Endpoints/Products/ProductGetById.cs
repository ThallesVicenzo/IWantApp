namespace IWantApp.Endpoints.Products;

public class ProductGetById
{
    public static string Template => "/products/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var product = context.Products.Include(p => p.Category).Where(p => p.Id == id).First();

        if (product == null)
            return Results.NotFound();

        var result = new ProductResponse(product.Name!, product.Category!.Name, product.Description!, product.HasStock, product.Price, product.IsActive);

        return Results.Ok(result);
    }
}
