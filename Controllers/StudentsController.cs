using Microsoft.AspNetCore.Mvc;
using studentApi.Dtos;

namespace studentApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StudentsController : ControllerBase
{
    private static List<Student> _students = new List<Student>()
    {
        new Student
        {
            Id = Guid.NewGuid(),
            Name = "Ibratbek",
            Grade = 3.99,
            Birthdate = DateTime.Parse("06.06.1999")
        },
        new Student
        {
            Id = Guid.NewGuid(),
            Name = "Javohir",
            Grade = 2.5,
            Birthdate = DateTime.Parse("12.15.2001")
        },
        new Student
        {
            Id = Guid.NewGuid(),
            Name = "Dilshod",
            Grade = 4.49,
            Birthdate = DateTime.Parse("10.22.2000")
        }
    };

    [HttpGet]
    public IActionResult ReadAll() => Ok(_students);

    [HttpGet]
    [Route("{id}")]
    public IActionResult ReadOne(Guid id)
    {
        var entity = _students.FirstOrDefault(s => s.Id == id);

        if(entity is null) return NotFound();
        
        return Ok(entity);
    }
    
    [HttpPost]
    public IActionResult Create(Student student)
    {        
        _students.Add(student);
        return CreatedAtAction(nameof(Create), student);
    }

    [HttpPut]
    public IActionResult Update(Guid id, Student student)
    {
        var entity = _students.FirstOrDefault(s => s.Id == id);
        
        if(entity is null) return NotFound();

        entity.Name = student.Name;
        entity.Grade = student.Grade;
        entity.Birthdate = student.Birthdate;

        return Accepted();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute]Guid id)
    {
        var entity = _students.FirstOrDefault(s => s.Id == id);

        if(entity is null) return NotFound();

        _students.Remove(entity);

        return Accepted();
    }       
}
