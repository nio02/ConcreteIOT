using System.ComponentModel.DataAnnotations;

namespace ConcreteIOT.Application.Models;

public class UserProject
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public ProjectRole Role { get; set; }
}

public enum ProjectRole
{
    OWNER,
    VISITOR
}