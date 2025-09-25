using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class ConcreteMix
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public double MixA { get; set; }
    
    [Required]
    public double MixB { get; set; }
}