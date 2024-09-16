namespace IWantApp.Endpoints.Products;

public class MostOrderedGet
{
    public static string Template => "/products/most-ordered";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(QueryMostOrderedProducts query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }
}
