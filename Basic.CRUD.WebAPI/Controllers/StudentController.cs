using System.Net;
using System.Net.Mime;
using Basic.CRUD.Entities.School;
using Basic.CRUD.WebAPI.Models.DTOs.Students;
using Microsoft.AspNetCore.Mvc;

namespace Basic.CRUD.WebAPI.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
public class StudentController : Controller
{
    private readonly SchoolDbContext _dbContext;
    
    public StudentController(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        try
        {
            var students = _dbContext.Student.ToList();
            return Ok(new { results = students });
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpGet("{studentKey}")]
    public IActionResult GetStudent(int studentKey)
    {
        try
        {
            var student = _dbContext.Student.FirstOrDefault(x => x.StudentKey == studentKey);
            return Ok(student);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentReq req)
    {
        try
        {
            var student = new Student()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                StudentId = req.StudentId
            };
            _dbContext.Student.Add(student);
            await _dbContext.SaveChangesAsync();
            
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpPut("{studentKey}")]
    public async Task<IActionResult> UpdateStudent(int studentKey, StudentReq req)
    {
        try
        {
            var student = _dbContext.Student.FirstOrDefault(x => x.StudentKey == studentKey);
            if (student is null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            student.FirstName = req.FirstName;
            student.LastName = req.LastName;
            student.StudentId = req.StudentId;
            await _dbContext.SaveChangesAsync();
            
            return Ok(student);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpDelete("{studentKey}")]
    public async Task<IActionResult> DeleteStudent(int studentKey)
    {
        try
        {
            var student = _dbContext.Student.FirstOrDefault(x => x.StudentKey == studentKey);
            if (student is null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            _dbContext.Student.Remove(student);
            await _dbContext.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}