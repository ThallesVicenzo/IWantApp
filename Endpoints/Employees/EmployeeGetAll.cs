using Dapper;
using Microsoft.Data.SqlClient;


namespace IWantApp.Endpoints.Employees;



public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows, IConfiguration configuration)
    {
        if (page == null)
            return Results.NotFound("Page can not be null!");
        if (page <= 0)
            return Results.BadRequest("Page value can not be less than 1");
        if (rows == null)
            return Results.NotFound("Rows can not be null!");
        if (rows > 10)
            return Results.BadRequest("Rows value can not be more than 10");


        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);

        var query = @"select Email, ClaimValue as Name
                from AspNetUsers u inner
                join AspNetUserClaims c
                on u.id = c.UserId and claimtype = 'Name'
                order by name
                OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

        var employees = db.Query<EmployeeResponse>(
            query,
            new
            {
                page,
                rows,
            }
            );

        return Results.Ok(employees);
    }
}
