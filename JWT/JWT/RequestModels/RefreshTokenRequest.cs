using System.ComponentModel.DataAnnotations;

namespace JWT.RequestModels;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; } = null!;
}