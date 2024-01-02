using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Enums;
using LearningManagement.Data.Models;
using LearningManagement.Infrastructure.ImageStorageHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IInstitutionAdminRepository _institutionAdminRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IStudentRepository _studentRepository;

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IFileStorageHelper _fileStorageHelper;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IInstitutionAdminRepository institutionAdminRepository, IHttpContextAccessor httpContextAccessor, IApplicationUserRepository applicationUserRepository, ITeacherRepository teacherRepository, IFileStorageHelper fileStorageHelper, IStudentRepository studentRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _institutionAdminRepository = institutionAdminRepository;
        _httpContextAccessor = httpContextAccessor;
        _applicationUserRepository = applicationUserRepository;
        _teacherRepository = teacherRepository;
        _fileStorageHelper = fileStorageHelper;
        _studentRepository = studentRepository;
    }

    public async Task<Result> SignUpAsync(SignUpModel model)
    {
        try
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Result.Fail("User already exists!");


            var institution = new Institution
            {
                InstitutionName = model.InstitutionName,
            };
            var user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                UserType = UserType.InstitutionAdmin,
                Institution = institution,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Result.Fail("User creation failed! Please check user details and try again.");

            if (user.InstitutionId != null)
            {
                var admin = new InstitutionAdminCreateModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    InstitutionId = user.InstitutionId.Value,
                    ApplicationUserId = user.Id
                };

                await _institutionAdminRepository.InstitutionAdminAddAsync(admin);
            }

            if (!await _roleManager.RoleExistsAsync(UserType.InstitutionAdmin.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(UserType.InstitutionAdmin.ToString()));


            if (await _roleManager.RoleExistsAsync(UserType.InstitutionAdmin.ToString()))
            {
                await _userManager.AddToRoleAsync(user, UserType.InstitutionAdmin.ToString());
            }

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> AddTeacherWithSignUpAsync(TeacherModel model)
    {
        try
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Result.Fail("User already exists!");

            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            var user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                UserType = UserType.Teacher,
                InstitutionId = institutionId,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Result.Fail("User creation failed! Please check user details and try again.");


            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageFileName = await _fileStorageHelper.SaveImageAsync(model.ImageFile);
                model.ImageFileName = imageFileName;
            }

            if (!await _roleManager.RoleExistsAsync(UserType.Teacher.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(UserType.Teacher.ToString()));


            if (await _roleManager.RoleExistsAsync(UserType.Teacher.ToString()))
            {
                await _userManager.AddToRoleAsync(user, UserType.Teacher.ToString());
            }

            return await _teacherRepository.TeacherAddAsync(institutionId.Value, user.Id, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> AddStudentWithSignUpAsync(StudentModel model)
    {
        try
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Result.Fail("User already exists!");

            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            var user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                UserType = UserType.Student,
                InstitutionId = institutionId,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Result.Fail("User creation failed! Please check user details and try again.");


            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageFileName = await _fileStorageHelper.SaveImageAsync(model.ImageFile);
                model.ImageFileName = imageFileName;
            }

            if (!await _roleManager.RoleExistsAsync(UserType.Student.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(UserType.Student.ToString()));


            if (await _roleManager.RoleExistsAsync(UserType.Student.ToString()))
            {
                await _userManager.AddToRoleAsync(user, UserType.Student.ToString());
            }

            return await _studentRepository.StudentAddAsync(institutionId.Value, user.Id, model);

        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<AdminViewModel>> InstitutionAdminInfoAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            return await _institutionAdminRepository.InstitutionAdminInfoAsync(appUser);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<AdminViewModel>> UpdateInstitutionAdminInfoAsync(AdminViewModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            return await _institutionAdminRepository.UpdateInstitutionAdminInfoAsync(appUser, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}