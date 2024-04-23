﻿using Conncection_to_DB.Product.Repository;
using Conncection_to_DB.ProductWarehouse.Controller.Request;
using Conncection_to_DB.ProductWarehouse.Controller.Response;
using Conncection_to_DB.ProductWarehouse.Repository;
using Conncection_to_DB.Warehouse.Repository;

namespace Conncection_to_DB.ProductWarehouse.Service;

public class ProductWarehouseService : IProductWarehouseService
{

    private readonly IProductWarehouseRepository _productWarehouseRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public ProductWarehouseService(IProductWarehouseRepository productWarehouseService,
        IProductRepository productRepository,
        IWarehouseRepository warehouseRepository)
    {
        _productWarehouseRepository = productWarehouseService;
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
    }

    public ProductWarehouseResponse CreateProduct(ProductWarehouseRequest productWarehouseRequest)
    {
        if (productWarehouseRequest.Amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
        var productEntity = _productRepository.Get(productWarehouseRequest.IdProduct) ??
                            throw new Exception("Product not found");
        
        var warehouseEntity = _warehouseRepository.Get(productWarehouseRequest.IdWarehouse) ??
                              throw new Exception("Warehouse not found");
        
        
        return new ProductWarehouseResponse()
        {
            IdProduct = productEntity.Id,
            IdWarehouse = productWarehouseRequest.IdWarehouse,
            Amount = productWarehouseRequest.Amount,
            CreatedAt = DateTime.Now
        };
    }
    
}