using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public required Role Role { get; set; }
}

public enum Role
{
    CLIENT,
    ADMIN
}