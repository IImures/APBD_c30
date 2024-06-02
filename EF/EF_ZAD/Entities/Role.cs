using System.ComponentModel.DataAnnotations;

namespace EF_ZAD.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public ICollection<Account> Accounts { get; } = new List<Account>();
}