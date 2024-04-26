using System.Data.SqlClient;
using Conncection_to_DB.Product.Entity;
using Conncection_to_DB.Warehouse.Entity;

namespace Conncection_to_DB.Warehouse.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private IConfiguration _configuration;
    
    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<WarehouseEntity?> Get(long id)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        
        var dr = await cmd.ExecuteReaderAsync();
        
        WarehouseEntity warehouse = null;
        if (await dr.ReadAsync())
        {
            warehouse = new WarehouseEntity
            {
                IdWarehouse = (int)dr["IdWarehouse"],
                Name = dr["Name"].ToString(),
                Address = dr["Address"].ToString()
            };
        }
        
        return warehouse;
    }
}