using System.ComponentModel.DataAnnotations;

namespace JWT.RequestModels;

public class LoginRequest
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}