using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class DataSet
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DateTime { get; set; }
    
    [Required]
    public double TempCore { get; set; }
    
    [Required]
    public double TempSurf { get; set; }
    
    [Required]
    public double DeltaTime { get; set; }
}