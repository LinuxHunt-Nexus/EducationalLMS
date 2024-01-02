using System.ComponentModel.DataAnnotations;

namespace LearningManagement.Data.ViewModels;


public class LoginModel
{
    [Required(ErrorMessage = "User Name is required")]
    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}