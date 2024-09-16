namespace IWantApp.Infra.Data;

public class QueryMostOrderedProducts
{
    private readonly IConfiguration configuration;

    public QueryMostOrderedProducts(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ProductsSoldResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);

        string query = @"
                SELECT
                    p.Id,
                    p.Name,
                    COUNT(*) AS Amount
                FROM
                    Orders o
                INNER JOIN OrderProducts op ON o.Id = op.OrdersId
                INNER JOIN Products p ON p.Id = op.ProductsId
                GROUP BY
                    p.Id, p.Name
                ORDER BY Amount DESC
                ";

        return await db.QueryAsync<ProductsSoldResponse>(query);
    }

}
