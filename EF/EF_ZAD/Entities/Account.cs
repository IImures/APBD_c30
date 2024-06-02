using System.ComponentModel.DataAnnotations;

namespace EF_ZAD.Entities;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();
    
    public ICollection<Product> Products { get; } = new List<Product>();
    
    [Required]
    public Role Role { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string FistName { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    
    [MaxLength(80)]
    [Required]
    public string Email { get; set; }
    
    [MaxLength(9)]
    public string? Phone { get; set; }
}