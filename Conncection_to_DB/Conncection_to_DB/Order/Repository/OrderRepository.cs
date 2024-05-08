using System.Data.SqlClient;
using Conncection_to_DB.Order.Entity;
using Conncection_to_DB.Product.Entity;

namespace Conncection_to_DB.Order.Repository;

public class OrderRepository : IOrderRepository
{
    private IConfiguration _configuration;
    
    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<OrderEntity?> GetByIdProductAndAmount(long idProduct, int amount)
    {
        await using var con =  new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt " +
                          "FROM \"Order\" " +
                          "WHERE IdProduct = @Id AND Amount = @Amount";
        cmd.Parameters.AddWithValue("@Id", idProduct);
        cmd.Parameters.AddWithValue("@Amount", amount);
        
        var dr = await cmd.ExecuteReaderAsync();
        
        OrderEntity order = null;
        if (await dr.ReadAsync())
        {
           order = new OrderEntity
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = (DateTime)dr["CreatedAt"],
                FulfilledAt = dr["FulfilledAt"] == DBNull.Value ? null : (DateTime)dr["FulfilledAt"]
            };
        }
        
        return order;
    }

    public async Task<OrderEntity?> GetById(int orderId)
    {
        await using var con =  new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt " +
                          "FROM \"Order\" " +
                          "WHERE IdOrder = @Id";
        cmd.Parameters.AddWithValue("@Id", orderId);
        
        var dr = await cmd.ExecuteReaderAsync();
        
        OrderEntity order = null;
        if (await dr.ReadAsync())
        {
            order = new OrderEntity
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = (DateTime)dr["CreatedAt"],
                FulfilledAt = (DateTime)dr["FulfilledAt"]
            };
        }
        
        return order;
    }

    public async Task<OrderEntity?> UpdateFulfilled(int orderId, DateTime dateTime)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Update \"Order\" Set FulfilledAt = @time Where IdOrder = @Id";
        cmd.Parameters.AddWithValue("@time", dateTime);
        cmd.Parameters.AddWithValue("@Id", orderId);

        await cmd.ExecuteNonQueryAsync();
        
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt " +
                          "FROM \"Order\" " +
                          "WHERE IdOrder = @Id";
        
        var dr = await cmd.ExecuteReaderAsync();
        
        OrderEntity order = null;
        if (await dr.ReadAsync())
        {
            order = new OrderEntity
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = (DateTime)dr["CreatedAt"],
                FulfilledAt = (DateTime)dr["FulfilledAt"]
            };
        }
        
        return order;
    }
}