using FluentResults;
using LearningManagement.Application;
using LearningManagement.Application.Services;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : Controller
{
    private readonly IAcademicSessionService _academicSessionService;
    private readonly IInstitutionClassService _institutionClassService;
    private readonly IInstitutionCourseService _institutionCourseService;
    public AdminController(IAcademicSessionService academicSessionService, IInstitutionClassService institutionClassService, IInstitutionCourseService institutionCourseService)
    {
        _academicSessionService = academicSessionService;
        _institutionClassService = institutionClassService;
        _institutionCourseService = institutionCourseService;
    }

    [HttpPost]
    [Route("academic-session-add")]
    public async Task<IActionResult> AcademicSessionAdd([FromBody] AcademicSessionModel model)
    {
       var result = await  _academicSessionService.AcademicSessionAddAsync(model);
       
       if(result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });
       
       return Ok();
    }

    // GET
    [HttpGet]
    [Route("academic-session-details")]
    public async Task<IActionResult> AcademicSessionDetails(int id)
    {
        var result = await _academicSessionService.AcademicSessionDetailsAsync(id);

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }

    // GET
    [HttpGet]
    [Route("academic-session-list")]
    public async Task<IActionResult> AcademicSessionList()
    {
        var result = await _academicSessionService.AcademicSessionListAsync();

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }

    [HttpPost]
    [Route("class-add")]
    public async Task<IActionResult> ClassAdd([FromBody] InstitutionClassModel model)
    {
        var result = await _institutionClassService.ClassAddAsync(model);

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok();
    }

    // GET
    [HttpGet]
    [Route("class-list")]
    public async Task<IActionResult> ClassList()
    {
        var result = await _institutionClassService.ClassListAsync();

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }

    // GET
    [HttpGet]
    [Route("class-details")]
    public async Task<IActionResult> ClassDetails(int id)
    {
        var result = await _institutionClassService.ClassDetailsAsync(id);

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }

    [HttpPost]
    [Route("course-add")]
    public async Task<IActionResult> CourseAdd([FromBody] InstitutionCourseModel model)
    {
        var result = await _institutionCourseService.CourseAddAsync(model);

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok();
    }


    [HttpGet]
    [Route("course-list")]
    public async Task<IActionResult> CourseList()
    {
        var result = await _institutionCourseService.CourseListAsync();

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }

    [HttpGet]
    [Route("course-details")]
    public async Task<IActionResult> CourseDetails(int id)
    {
        var result = await _institutionCourseService.CourseDetailsAsync(id);

        if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Status = "Error", Message = result.Errors.First().Message });

        return Ok(result.ValueOrDefault);
    }
    
    [HttpPost]
    [Route("student-add")]
    public async Task<IActionResult> StudentAdd([FromBody] StudentModel model)
    {
        return Ok();
    }

    [HttpGet]
    [Route("student-list")]
    public async Task<IActionResult> StudentList()
    {
        return Ok();
    }

    [HttpGet]
    [Route("student-details")]
    public async Task<IActionResult> StudentDetails(int id)
    {
        return Ok();
    }
    [HttpPost]
    [Route("teacher-add")]
    public async Task<IActionResult> TeacherAdd([FromBody] TeacherModel model)
    {
        return Ok();
    }

    [HttpGet]
    [Route("teacher-list")]
    public async Task<IActionResult> TeacherList()
    {
        return Ok();
    }

    [HttpGet]
    [Route("teacher-details")]
    public async Task<IActionResult> TeacherDetails(int id)
    {
        return Ok();
    }

    [HttpPost]
    [Route("teacher-assign-course")]
    public async Task<IActionResult> TeacherAssignCourse(int teacherId, int courseId, int institutionClassId)
    {
        return Ok();
    }

    [HttpGet]
    [Route("teacher-course-details")]
    public async Task<IActionResult> TeacherAssignCourseDetails(int teacherWiseCourseContentId)
    {
        return Ok();
    }

    [HttpPost]
    [Route("teacher-course-content-add")]
    public async Task<IActionResult> CourseContentAdd(TeacherWiseCourseContentModel model)
    {
        return Ok();
    }

    [HttpPost]
    [Route("student-assign-class")]
    public async Task<IActionResult> StudentAssignClass(int academicSessionId, int InstitutionStudent, int institutionClassId)
    {
        return Ok();
    }

    [HttpPost]
    [Route("student-assign-course")]
    public async Task<IActionResult> StudentAssignCourse(TeacherWiseCourseContentModel model)
    {
        return Ok();
    }
}