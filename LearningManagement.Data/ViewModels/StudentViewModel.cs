namespace LearningManagement.Data.ViewModels;

public class StudentViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FatherName { get; set; } = null!;
    public string MotherName { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string Gender { get; set; } = null!;
    public string? Religion { get; set; }
    public string? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? AdmissionDate { get; set; }
    public string? AdmissionNumber { get; set; }
    public int InstitutionClassId { get; set; }
    public string ClassName { get; set; } = null!;
    public int AcademicSessionId { get; set; }
    public string SessionName { get; set; } = null!;
}