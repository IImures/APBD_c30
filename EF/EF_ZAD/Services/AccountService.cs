using EF_ZAD.Context;
using EF_ZAD.Controllers.Responses;
using EF_ZAD.Entities;
using EF_ZAD.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EF_ZAD.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationContext _context;
    
    public AccountService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<AccountResponse> getAccountById(int id)
    {
        Account? account = await _context.Accounts
            .Include(e=> e.ShoppingCarts)
                .ThenInclude(e1=> e1.Product)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.AccountId == id);
        if(account == null)
        {
            throw new NotFoundException($"Account with id {id} not found");
        }

        var shoppingCarts = CreateShoppingList(account.ShoppingCarts);
        

        return new AccountResponse()
        {
            FirstName = account.FistName,
            LastName = account.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = account.Role.Name,
            Carts = shoppingCarts
        };
    }
    
    private List<object> CreateShoppingList(ICollection<ShoppingCart> shoppingCarts)
    {
        var shoppingList = new List<object>();
        foreach (var cart in shoppingCarts)
        {
            shoppingList.Add(new
            {
                cart.Product.ProductId,
                cart.Product.Name,
                cart.Amount
            });
        }

        return shoppingList;
    }
}