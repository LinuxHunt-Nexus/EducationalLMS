﻿using LearningManagement.Data.Models;

namespace LearningManagement.Data.ViewModels;

public class AcademicSessionModel
{
    public int AcademicSessionId { get; set; }
    public string SessionName { get; set; } = null!;
    public string? SessionDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // MAHADI
    // Additional properties
    public bool IsActive { get; set; }
    public string? AcademicCalendar { get; set; }
    public virtual ICollection<InstitutionClass> OfferedClasses { get; set; } = new HashSet<InstitutionClass>();  // List of classes offered during the academic session.
    public virtual ICollection<InstitutionCourse> OfferedCourses { get; set; } = new HashSet<InstitutionCourse>();  // List of courses offered during the academic session.
    public string? SessionDirector { get; set; }
    public DateTime? SessionTime { get; set; }
    public int? TotalStudentsEnrolled { get; set; }
    public decimal? AverageStudentAttendance { get; set; }
    public decimal? AverageStudentPerformance { get; set; }
    public string? Achievements { get; set; }
    public string? ChallengesFaced { get; set; }
    public string? FutureGoals { get; set; }
}