using LearningManagement.Data.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LearningManagement.Data.ViewModels;

public class StudentModel
{
    public int InstitutionStudentId { get; set; }


    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FatherName { get; set; } = null!;
    public string MotherName { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Gender { get; set; } = null!;
    public string? Religion { get; set; }
    public string? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? AdmissionDate { get; set; }
    public string? AdmissionNumber { get; set; }

    public int AcademicSessionId { get; set; }
    public int InstitutionClassId { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}