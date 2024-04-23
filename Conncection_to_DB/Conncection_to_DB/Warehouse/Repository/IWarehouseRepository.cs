using Conncection_to_DB.Warehouse.Entity;

namespace Conncection_to_DB.Warehouse.Repository;

public interface IWarehouseRepository
{
    WarehouseEntity Get(long idWarehouse);
}