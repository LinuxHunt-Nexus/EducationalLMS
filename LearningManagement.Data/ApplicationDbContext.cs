using LearningManagement.Data.EntityConfigurations;
using LearningManagement.Data.Models;
using LearningManagement.Data.Seeder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public virtual DbSet<AcademicSession> AcademicSessions { get; set; }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<Institution> Institutions { get; set; }
    public virtual DbSet<InstitutionAdmin> InstitutionAdmins  { get; set; }
    public virtual DbSet<InstitutionCourse> InstitutionCourses { get; set; }
    public virtual DbSet<InstitutionClass> InstitutionClasses { get; set; }
    public virtual DbSet<InstitutionStudent> InstitutionStudents { get; set; }
    public virtual DbSet<InstitutionTeacher> InstitutionTeachers { get; set; }
    public virtual DbSet<StudentInClass> StudentInClasses { get; set; }
    public virtual DbSet<TeacherWiseCourse> TeacherWiseCourses { get; set; }
    public virtual DbSet<TeacherWiseCourseContent> TeacherWiseCourseContents { get; set; }
    public virtual DbSet<TeacherWiseStudentCourse> TeacherWiseStudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {  
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AcademicSessionConfiguration());
        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new InstitutionAdminConfiguration());
        builder.ApplyConfiguration(new InstitutionClassConfiguration());
        builder.ApplyConfiguration(new InstitutionConfiguration());
        builder.ApplyConfiguration(new InstitutionCourseConfiguration());
        builder.ApplyConfiguration(new InstitutionStudentConfiguration());
        builder.ApplyConfiguration(new InstitutionTeacherConfiguration());
        builder.ApplyConfiguration(new StudentInClassConfiguration());
        builder.ApplyConfiguration(new TeacherWiseCourseConfiguration());
        builder.ApplyConfiguration(new TeacherWiseCourseContentConfiguration());
        builder.ApplyConfiguration(new TeacherWiseStudentCourseConfiguration());


        builder.SeedRoleData();
        builder.SeedSuperAdminData();
    }
}