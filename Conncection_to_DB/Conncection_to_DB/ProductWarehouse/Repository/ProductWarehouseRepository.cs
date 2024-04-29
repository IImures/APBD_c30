using System.Data.SqlClient;
using Conncection_to_DB.Product.Entity;
using Conncection_to_DB.ProductWarehouse.Entity;

namespace Conncection_to_DB.ProductWarehouse.Repository;

public class ProductWarehouseRepository : IProductWarehouseRepository
{
    
    private readonly IConfiguration _configuration;
    
    public ProductWarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<ProductWarehouseEntity> SaveProduct(ProductWarehouseEntity productWarehouseEntity)
    {
        await using var con =  new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, " +
                          "IdOrder, Amount, Price, CreatedAt) " +
                          "VALUES (@IdWarehouse, @IdProduct, " +
                          "@IdOrder, @Amount, @Price, @CreatedAt)";
        cmd.Parameters.AddWithValue("@IdWarehouse", productWarehouseEntity.IdWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", productWarehouseEntity.IdProduct);
        cmd.Parameters.AddWithValue("@IdOrder", productWarehouseEntity.IdOrder);
        cmd.Parameters.AddWithValue("@Amount", productWarehouseEntity.Amount);
        cmd.Parameters.AddWithValue("@Price", productWarehouseEntity.Price);
        cmd.Parameters.AddWithValue("@CreatedAt", productWarehouseEntity.CreatedAt);

        await cmd.ExecuteNonQueryAsync();
        
        cmd.CommandText = "SELECT MAX(IdProductWarehouse) FROM Product_Warehouse";
        var dr = await cmd.ExecuteReaderAsync();
        
        ProductWarehouseEntity product = null;
        if (await dr.ReadAsync())
        {
            product = new ProductWarehouseEntity
            {
                IdProductWarehouse = (int)dr[0],
                IdWarehouse = productWarehouseEntity.IdWarehouse,
                IdProduct = productWarehouseEntity.IdProduct,
                IdOrder = productWarehouseEntity.IdOrder,
                Amount = productWarehouseEntity.Amount,
                Price = productWarehouseEntity.Price,
                CreatedAt = productWarehouseEntity.CreatedAt
            };
        }

        return product!;
    }

    public async Task<ProductWarehouseEntity?> GetByOrderId(long OrderID)
    {
        await using var con =  new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdProductWarehouse, IdWarehouse, IdProduct, " +
                          "IdOrder, Amount, Price, CreatedAt " +
                          "FROM Product_Warehouse " +
                          "WHERE IdOrder = @Id";
        cmd.Parameters.AddWithValue("@Id", OrderID);
        
        var dr = await cmd.ExecuteReaderAsync();
        
        ProductWarehouseEntity product = null;
        if (await dr.ReadAsync())
        {
            product = new ProductWarehouseEntity
            {
                IdProductWarehouse = (int)dr["IdProductWarehouse"],
                IdWarehouse = (int)dr["IdWarehouse"],
                IdProduct = (int)dr["IdProduct"],
                IdOrder = (int)dr["IdOrder"],
                Amount = (int)dr["Amount"],
                Price = Convert.ToDouble(dr["Price"]),
                CreatedAt = (DateTime)dr["CreatedAt"]
            };
        }
        
        return product;
    }
    
}