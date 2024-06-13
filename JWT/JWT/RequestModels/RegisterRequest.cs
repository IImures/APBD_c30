using System.ComponentModel.DataAnnotations;

namespace JWT.RequestModels;

public class RegisterRequest
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    [Required]
    public string Password { get; set; } = null!;
}