using EF_ZAD.Controllers.Requests;
using EF_ZAD.Entities;
using FluentValidation;

namespace EF_ZAD.Validators;

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
        RuleFor(x => x.Weight).GreaterThan(0).NotNull();
        RuleFor(x => x.Width).GreaterThan(0).NotNull();
        RuleFor(x => x.Height).GreaterThan(0).NotNull();
        RuleFor(x => x.Depth).GreaterThan(0).NotNull();
        RuleFor(x => x.Categories).NotEmpty().NotNull();
    }
    
}