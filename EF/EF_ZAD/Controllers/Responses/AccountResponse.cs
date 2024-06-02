using EF_ZAD.Entities;

namespace EF_ZAD.Controllers.Responses;

public class AccountResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; }
    public ICollection<object> Carts { get; set; }
}