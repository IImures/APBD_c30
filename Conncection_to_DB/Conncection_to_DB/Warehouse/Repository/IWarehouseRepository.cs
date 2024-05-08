using Conncection_to_DB.Warehouse.Entity;

namespace Conncection_to_DB.Warehouse.Repository;

public interface IWarehouseRepository
{
    Task<WarehouseEntity?> Get(long idWarehouse);
}