using EF_ZAD.Controllers.Requests;
using EF_ZAD.Controllers.Responses;
using EF_ZAD.Entities;

namespace EF_ZAD.Services;

public interface IProductService
{
    Task<ProductResponse> CreateProduct(ProductRequest productRequest);
}