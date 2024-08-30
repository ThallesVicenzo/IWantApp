using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;


namespace IWantApp.Endpoints.Employees;



public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        if (page == null)
            return Results.BadRequest("Page can not be null!");
        if (page <= 0)
            return Results.BadRequest("Page value can not be less than 1");
        if (rows == null)
            return Results.BadRequest("Rows can not be null!");
        if (rows > 10)
            return Results.BadRequest("Rows value can not be more than 10");

        return Results.Ok(query.Execute(page.Value, rows.Value));
    }
}
