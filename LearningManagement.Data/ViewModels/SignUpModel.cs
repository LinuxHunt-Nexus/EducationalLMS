using System.ComponentModel.DataAnnotations;

namespace LearningManagement.Data.ViewModels;

public class SignUpModel
{
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "First Name is required")]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Institution name is required")]
    public string InstitutionName { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required")]
    public string? ConfirmPassword { get; set; }
}