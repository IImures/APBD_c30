using System.Transactions;
using Conncection_to_DB.Exceptions;
using Conncection_to_DB.Order.Repository;
using Conncection_to_DB.Product.Repository;
using Conncection_to_DB.ProductWarehouse.Controller.Request;
using Conncection_to_DB.ProductWarehouse.Controller.Response;
using Conncection_to_DB.ProductWarehouse.Entity;
using Conncection_to_DB.ProductWarehouse.Repository;
using Conncection_to_DB.Warehouse.Repository;

namespace Conncection_to_DB.ProductWarehouse.Service;

public class ProductWarehouseService : IProductWarehouseService
{

    private readonly IProductWarehouseRepository _productWarehouseRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;

    public ProductWarehouseService(
        IProductWarehouseRepository productWarehouseService,
        IProductRepository productRepository,
        IWarehouseRepository warehouseRepository,
        IOrderRepository orderRepository
    )
    {
        _productWarehouseRepository = productWarehouseService;
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
    }

    public async Task<ProductWarehouseResponse> CreateProduct(ProductWarehouseRequest request)
    {
        if (request.Amount <= 0)
        {
            throw new WrongValue("Amount must be greater than 0");
        }

        var productEntity = await _productRepository.Get(request.IdProduct) ??
                            throw new NotFound($"Product with id {request.IdProduct} not found");

        var warehouseEntity = await _warehouseRepository.Get(request.IdWarehouse) ??
                              throw new NotFound($"Warehouse with id: {request.IdWarehouse} not found");
        var orderEntity = await _orderRepository.GetByIdProductAndAmount(request.IdProduct, request.Amount) ??
                          throw new NotFound($"Such Order doed not exist");
        if (orderEntity.CreatedAt > request.CreatedAt)
        {
            throw new WrongValue("Order was created after product was added to warehouse");
        }

        var productWarehouseEntity = await _productWarehouseRepository.GetByOrderId(orderEntity.IdOrder);
        if (productWarehouseEntity != null)
        {
            throw new OrderFulfilled("Order already fulfilled");
        }

        try
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _orderRepository.UpdateFulfilled(orderEntity.IdOrder, DateTime.Now);
                ProductWarehouseEntity productWarehouse =
                    await _productWarehouseRepository.SaveProduct(new ProductWarehouseEntity()
                    {
                        IdWarehouse = warehouseEntity.IdWarehouse,
                        IdProduct = productEntity.Id,
                        IdOrder = orderEntity.IdOrder,
                        Amount = request.Amount,
                        Price = productEntity.Price,
                        CreatedAt = request.CreatedAt
                    });
                transaction.Complete();
            }
        }catch (TransactionAbortedException ex)
        {
            Console.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
        }


        return new ProductWarehouseResponse()
        {
            IdProduct = productEntity.Id,
            IdWarehouse = request.IdWarehouse,
            Amount = request.Amount,
            CreatedAt = DateTime.Now
        };
    }
    
}