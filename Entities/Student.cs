namespace studentApi.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Grade { get; set; }
    public DateTime Birthdate { get; set; } 
    
}