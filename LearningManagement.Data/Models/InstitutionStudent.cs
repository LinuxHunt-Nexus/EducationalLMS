﻿namespace LearningManagement.Data.Models;

public class InstitutionStudent
{
    public int InstitutionStudentId { get; set; }
    public int InstitutionId { get; set; }
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



    public DateTime CreatedAtUtc { get; set; }

    public Institution Institution { get; set; } = null!;

    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<StudentInClass> StudentInClasses { get; set; } = new HashSet<StudentInClass>();
}