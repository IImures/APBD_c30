using Conncection_to_DB.ProductWarehouse.Entity;

namespace Conncection_to_DB.ProductWarehouse.Repository;

public interface IProductWarehouseRepository
{
    Task<ProductWarehouseEntity> SaveProduct(ProductWarehouseEntity productWarehouseEntity);
    
    Task<ProductWarehouseEntity?> GetByOrderId(long OrderID);
}