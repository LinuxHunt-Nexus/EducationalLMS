using LearningManagement.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;
using LearningManagement.Application.Services;

namespace LearningManagement.Web.Controllers;
[Authorize]
public class AuthController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IAuthService _authService;
    public AuthController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IAuthService authService)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _authService = authService;
    }


    [AllowAnonymous]
    public async Task<IActionResult> SignUp()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var user = await _userManager.GetUserAsync(User);
            return LocalRedirect(await UserRedirect(user));
        }

        return View();
    }

    //POST: Index
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(SignUpModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _authService.SignUpAsync(model);

        if (result.IsFailed)
        {
            ModelState.AddModelError("FirstName", result.Errors.First().Message);
            return View(model);
        }

        return RedirectToAction("Login");


    }
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var user = await _userManager.GetUserAsync(User);
            return LocalRedirect(await UserRedirect(user));
        }

        return View();
    }

    //POST: Index
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        var result =
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

        if (result.Succeeded)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);

            var role = await GetRole(user);
            // Add a claim to the user's identity
            var claims = new List<Claim>
                {
                    new Claim("Email", user.Email),
                    new Claim("Role", role.ToString())
                };
            await _userManager.AddClaimsAsync(user, claims);

            return LocalRedirect(await UserRedirect(user));
        }

        ModelState.AddModelError(string.Empty, "Incorrect username or password");
        return View(model);
    }


    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            // This needs to be a redirect so that the browser performs a new
            // request and the identity for the user gets updated.
            return LocalRedirect(Url.Content($"~/Home/index"));
        }
    }

    // GET: ChangePassword
    public ActionResult ChangePassword()
    {
        return View();
    }

    // POST: ChangePassword
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.GetUserAsync(User);

        if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
            foreach (var error in changePasswordResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        await _signInManager.RefreshSignInAsync(user);

        return RedirectToAction("Index", "Admin", new { Message = "Your password has been changed." });
    }

    private async Task<string> UserRedirect(ApplicationUser user, string? returnUrl = null)
    {
        if (await _userManager.IsInRoleAsync(user, UserType.InstitutionAdmin.ToString()))
            return returnUrl ?? Url.Content($"/Admin");

        return returnUrl ?? Url.Content($"/Home/index");
    }
    private async Task<UserType> GetRole(ApplicationUser user)
    {
        UserType role;

        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Any()) return UserType.Unknown;

        return Enum.TryParse<UserType>(roles[0], true, out role) ? role : UserType.Unknown;
    }
}