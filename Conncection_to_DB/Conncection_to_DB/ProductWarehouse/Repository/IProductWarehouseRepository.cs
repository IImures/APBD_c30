using Conncection_to_DB.ProductWarehouse.Entity;

namespace Conncection_to_DB.ProductWarehouse.Repository;

public interface IProductWarehouseRepository
{
    ProductWarehouseEntity SaveProduct(ProductWarehouseEntity productWarehouseEntity);
}