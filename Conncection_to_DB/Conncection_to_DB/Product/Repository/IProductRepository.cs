using Conncection_to_DB.Product.Entity;

namespace Conncection_to_DB.Product.Repository;

public interface IProductRepository
{
    Task<ProductEntity?> Get(long id);
}