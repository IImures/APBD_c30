using System.Data.SqlClient;
using System.Data.SqlTypes;
using Conncection_to_DB.Product.Entity;

namespace Conncection_to_DB.Product.Repository;

public class ProductRepository : IProductRepository
{
    private IConfiguration _configuration;
    
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ProductEntity?> Get(long id)
    {
        await using var con =  new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        
        var dr = await cmd.ExecuteReaderAsync();
        
        ProductEntity product = null;
        if (await dr.ReadAsync())
        {
            product = new ProductEntity
            {
                Id = (int)dr["IdProduct"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Price = Convert.ToDouble(dr["Price"])
            };
        }
        
        return product;
    }
}