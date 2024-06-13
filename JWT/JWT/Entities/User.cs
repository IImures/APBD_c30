using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT.Entities;

public class User
{
    [Key]
    public long UserId { get; set; }
    
    [MaxLength(50)]
    [Index(IsUnique = true)]
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [MaxLength(200)]
    [Column("password")]
    public string Password { get; set; } = null!;
}