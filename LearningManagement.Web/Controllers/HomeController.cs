using LearningManagement.Application;
using LearningManagement.Application.Services;
using LearningManagement.Data.Models;
using LearningManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Enums;

namespace LearningManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;
        private readonly IAcademicSessionService _academicSessionService;
        public HomeController(ILogger<HomeController> logger, IAcademicSessionService academicSessionService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IAuthService authService)
        {
            _logger = logger;
            _academicSessionService = academicSessionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        public async Task<IActionResult> IndexAsync()
        {
           var h =  HttpContext;
            var user = User.Identity.Name;
            var model = new AcademicSessionModel(); 
            await _academicSessionService.AcademicSessionAddAsync(model);
            return View();
        }

        //POST: Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(LoginModel model, string? returnUrl = null)
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

            ModelState.AddModelError("Password", "Incorrect username or password");
            return View(model);
        }

        public async Task<IActionResult> SignUpAsync()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                ModelState.AddModelError("Email", "User already exists!");
                return View(model);
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Password Does Not Match");
                return View(model);
            }

            if (!ModelState.IsValid) return View(model);

            var result = await _authService.SignUpAsync(model);

            if (result.IsFailed)
            {
                ModelState.AddModelError("FirstName", result.Errors.First().Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<string> UserRedirect(ApplicationUser user, string? returnUrl = null)
        {
            if (await _userManager.IsInRoleAsync(user, UserType.AppAdmin.ToString()))
                return returnUrl ?? Url.Content($"~/AppAdmin/Dashboard");
            if (await _userManager.IsInRoleAsync(user, UserType.InstitutionAdmin.ToString()))
                return returnUrl ?? Url.Content($"~/Admin/Dashboard");
            if (await _userManager.IsInRoleAsync(user, UserType.Teacher.ToString()))
                return returnUrl ?? Url.Content($"~/Teacher/Dashboard");
            if (await _userManager.IsInRoleAsync(user, UserType.Student.ToString()))
                return returnUrl ?? Url.Content($"~/Student/Dashboard");
          
            return returnUrl ?? Url.Content($"~/Home/index");
        }
        private async Task<UserType> GetRole(ApplicationUser user)
        {
            UserType role;

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Any()) return UserType.Unknown;

            return Enum.TryParse<UserType>(roles[0], true, out role) ? role : UserType.Unknown;
        }
    }
}