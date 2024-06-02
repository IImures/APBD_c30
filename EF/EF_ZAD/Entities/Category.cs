using System.ComponentModel.DataAnnotations;

namespace EF_ZAD.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; } = new List<Product>();
}