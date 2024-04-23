using Conncection_to_DB.Product.Entity;

namespace Conncection_to_DB.Product.Repository;

public interface IProductRepository
{
    ProductEntity? Get(long id);
}