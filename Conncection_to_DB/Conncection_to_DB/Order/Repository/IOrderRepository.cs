using Conncection_to_DB.Order.Entity;

namespace Conncection_to_DB.Order.Repository;

public interface IOrderRepository
{
    Task<OrderEntity?> GetByIdProductAndAmount(long idProduct, int amount);
    Task<OrderEntity?> UpdateFulfilled(int orderEntityIdOrder, DateTime now);
    Task<OrderEntity?> GetById(int orderId);
}