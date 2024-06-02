using EF_ZAD.Controllers.Responses;

namespace EF_ZAD.Services;

public interface IAccountService
{
    Task<AccountResponse> getAccountById(int id);
}