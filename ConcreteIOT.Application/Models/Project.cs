using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string? Company { get; set; }
}