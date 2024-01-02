using LearningManagement.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace LearningManagement.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? InstitutionId { get; set; }
        public Institution? Institution { get; set; }
        public UserType? UserType { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public InstitutionAdmin? InstitutionAdmin { get; set;}
        public InstitutionStudent? InstitutionStudent { get; set;}
        public InstitutionTeacher? InstitutionTeacher { get; set;}
    }
}
