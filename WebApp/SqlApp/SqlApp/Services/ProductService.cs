namespace SqlApp.Services;

using SqlApp.Models;
using System.Data.SqlClient;

public class ProductService
{
    private static readonly string _dbSource = "piciupol-sqlserver.database.windows.net";
    private static readonly string _dbUser = "sqladmin";
    private static readonly string _dbPassword = "Pa$$word";
    private static readonly string _dbName = "appdb";

    private SqlConnection GetConnection()
    {
        var builder = new SqlConnectionStringBuilder();
        builder.DataSource = _dbSource;
        builder.Password = _dbPassword;
        builder.UserID = _dbUser;
        builder.InitialCatalog = _dbName;

        return new SqlConnection(builder.ConnectionString);
    }

    public List<Product> GetProducts()
    {
        var connection = GetConnection();

        var productList = new List<Product>();
        var query = "select ProductId, ProductName, Quantity from Products";

        connection.Open();
        var sqlCommand = new SqlCommand(query, connection);
        using(var reader = sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                productList.Add(new Product
                {
                    ProductID = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                });
            }
        }

        connection.Close();

        return productList;
    }
}
