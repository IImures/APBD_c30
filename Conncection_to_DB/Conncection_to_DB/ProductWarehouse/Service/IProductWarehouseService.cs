using Conncection_to_DB.ProductWarehouse.Controller.Request;
using Conncection_to_DB.ProductWarehouse.Controller.Response;

namespace Conncection_to_DB.ProductWarehouse.Service;

public interface IProductWarehouseService
{
    Task<ProductWarehouseResponse> CreateProduct(ProductWarehouseRequest request);
}