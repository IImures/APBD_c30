using EF_ZAD.Context;
using EF_ZAD.Controllers.Requests;
using EF_ZAD.Controllers.Responses;
using EF_ZAD.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_ZAD.Services;

public class ProductService : IProductService
{

    private readonly ApplicationContext _context;
    
    public ProductService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<ProductResponse> CreateProduct(ProductRequest productRequest)
    {
        Product toSave = new()
        {
            Name = productRequest.Name,
            Width = productRequest.Width,
            Height = productRequest.Height,
            Depth = productRequest.Depth,
            Weight = productRequest.Weight
        };
        
        List<Category> categories = await _context.Category
            .Where(e => productRequest.Categories.Contains(e.CategoryId))
            .ToListAsync();
        foreach (var category in categories)
        {
            toSave.Categories.Add(category);
        }
        
        await _context.Products.AddAsync(toSave);
        await _context.SaveChangesAsync();

        return new ProductResponse()
        {
            ProductId = toSave.ProductId,
            Name = toSave.Name,
            Width = toSave.Width,
            Height = toSave.Height,
            Depth = toSave.Depth,
            Weight = toSave.Weight,
            Categories =  CreateCategoriesResponse(toSave.Categories)
        };
    }
    
    private List<object> CreateCategoriesResponse(ICollection<Category> categories)
    {
        var categoriesResponse = new List<object>();
        foreach (var category in categories)
        {
            categoriesResponse.Add(new
            {
                category.CategoryId,
                category.Name
            });
        }

        return categoriesResponse;
    }
}