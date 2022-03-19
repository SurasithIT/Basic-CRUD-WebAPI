using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Basic.CRUD.WebAPI.Models.DTOs.Students;

public class StudentReq
{
    [Required]
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    [Required]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    [Required]
    [JsonPropertyName("studentId")]
    public string StudentId { get; set; }
}