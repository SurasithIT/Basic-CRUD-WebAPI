using System.ComponentModel.DataAnnotations;

namespace Basic.CRUD.Entities.School;

public class Student
{
    [Key]
    public int StudentKey { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string StudentId { get; set; }
}