using LearningManagement.Application.Services;
using LearningManagement.Data.ViewModels;
using LearningManagement.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearningManagement.Web.Controllers;
[Authorize(Roles = "Teacher")]
public class TeacherController : Controller
{
    private readonly IAcademicSessionService _academicSessionService;
    private readonly IInstitutionClassService _institutionClassService;
    private readonly IInstitutionCourseService _institutionCourseService;
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;
    private readonly IAuthService _authService;
    private readonly IInstitutionService _institutionService;
    private readonly NotificationHelper _notificationHelper;

    // GET
    public TeacherController(IAcademicSessionService academicSessionService, IInstitutionClassService institutionClassService, 
        IInstitutionCourseService institutionCourseService, IAuthService authService, ITeacherService teacherService, 
        IStudentService studentService, NotificationHelper notificationHelper, IInstitutionService institutionService)
    {
        _academicSessionService = academicSessionService;
        _institutionClassService = institutionClassService;
        _institutionCourseService = institutionCourseService;
        _authService = authService;
        _teacherService = teacherService;
        _studentService = studentService;
        _notificationHelper = notificationHelper;
        _institutionService = institutionService;
    }

    // GET
    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult AddCourse()
    {
        return View();
    }


    // Post
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] InstitutionCourseModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel { Message = "Invalid data" });

        var addResult = await _institutionCourseService.CourseAddAsync(model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    public async Task<IActionResult> GetCourse()
    {
        var result = await _institutionCourseService.CourseListAsync();
        return Json(result.ValueOrDefault);
    }
}