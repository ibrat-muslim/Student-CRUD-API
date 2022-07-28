using System.ComponentModel.DataAnnotations;
namespace studentApi.Dtos;

public class Student
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }
    [Required]
    [Range(0.0,5.0)]
    public double Grade { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; } 
    
}
