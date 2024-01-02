namespace LearningManagement.Data.Models;

public class InstitutionCourse
{
    public int InstitutionCourseId { get; set; }
    public int InstitutionId { get; set; }
    public string CourseName { get; set; } = null!;
    public string? Descriptions { get; set; }
    public string? Prerequisites { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    public Institution Institution { get; set; } = null!;

    // MAHADI
    // Additional properties
    //public int Credits { get; set; }
    //public int DurationInWeeks { get; set; }
    //public string? Syllabus { get; set; }
    //public bool IsElective { get; set; }
    //public string? Department { get; set; }
    //public int MaximumEnrollment { get; set; }
    //public int MinimumEnrollment { get; set; }
    //public decimal TuitionFee { get; set; }
    //public DateTime StartDate { get; set; }
    //public DateTime EndDate { get; set; }
    //public string? Schedule { get; set; }
    //public string? AssessmentMethods { get; set; }
    //public string? LeadInstructor { get; set; }
    //public string? CourseNotes { get; set; }
    //public string? RecommendedTextbooks { get; set; }
    //public string? AdditionalResources { get; set; }

    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}