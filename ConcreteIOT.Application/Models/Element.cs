using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class Element
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}