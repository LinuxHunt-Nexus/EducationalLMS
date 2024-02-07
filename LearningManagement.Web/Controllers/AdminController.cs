using LearningManagement.Application.Services;
using LearningManagement.Data.Enums;
using LearningManagement.Data.ViewModels;
using LearningManagement.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Web.Controllers;

[Authorize(Roles = "InstitutionAdmin")]
public class AdminController : Controller
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
    public AdminController(IAcademicSessionService academicSessionService, IInstitutionClassService institutionClassService, IInstitutionCourseService institutionCourseService, IAuthService authService, ITeacherService teacherService, IStudentService studentService, NotificationHelper notificationHelper, IInstitutionService institutionService)
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
    public IActionResult AcademicYear()
    {
        return View();
    }

    //POST: years from ajax
    [HttpPost]
    public async Task<IActionResult> AcademicYear([FromBody] AcademicSessionModel model)
    {
        try
        {
            if (model == null) 
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel { Message = "Invalid data" });

            var addResult = await _academicSessionService.AcademicSessionAddAsync(model).ConfigureAwait(false);

            if (addResult.IsSuccess) 
            return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    // GET: years from ajax
    public async Task<IActionResult> GetAcademicYear()
    {
        var result = await _academicSessionService.AcademicSessionListAsync();
        return Json(result.ValueOrDefault);
    }



    // GET
    public IActionResult AddClass()
    {
        return View();
    }

    // Post
    [HttpPost]
    public async Task<IActionResult> AddClass([FromBody] InstitutionClassModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel { Message = "Invalid data" });


        var addResult = await _institutionClassService.ClassAddAsync(model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }


    public async Task<IActionResult> GetClass()
    {
        var result = await _institutionClassService.ClassListAsync();
        return Json(result.ValueOrDefault);
    }


    // GET
    public  IActionResult AddCourse()
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

    // GET
    public IActionResult AddTeacher()
    {
        return View();
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTeacher(TeacherModel model)
    {

        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var addResult = await _authService.AddTeacherWithSignUpAsync(model);

            if (addResult.IsSuccess)
            {
                return RedirectToAction("Teacher");
            }
            ModelState.AddModelError("LastName", addResult.Errors.First().Message);
            return View(model);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    // GET
    public async Task<IActionResult> AddStudent()
    {
        var getSessionResult = await _academicSessionService.AcademicSessionListAsync();

        var sessions = getSessionResult.ValueOrDefault;

        var getClassResult = await _institutionClassService.ClassListAsync();

        var classes = getClassResult.ValueOrDefault;

        ViewBag.AcademicYears = new SelectList(sessions, "AcademicSessionId", "SessionName");
        ViewBag.Classes = new SelectList(classes, "InstitutionClassId", "ClassName");
        return View();
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddStudent(StudentModel model)
    {
        var getSessionResult = await _academicSessionService.AcademicSessionListAsync();

        var sessions = getSessionResult.ValueOrDefault;

        var getClassResult = await _institutionClassService.ClassListAsync();

        var classes = getClassResult.ValueOrDefault;

        ViewBag.AcademicYears = new SelectList(sessions, "AcademicSessionId", "SessionName");
        ViewBag.Classes = new SelectList(classes, "InstitutionClassId", "ClassName");


        if (!ModelState.IsValid) return View(model);

        var addResult = await _authService.AddStudentWithSignUpAsync(model);

        if (addResult.IsSuccess)
        {
            return RedirectToAction("AddStudent");
        }

        ModelState.AddModelError("LastName", addResult.Errors.First().Message);
        return View(model);
    }


    public async Task<IActionResult> AdminInfo()
    {
        var model = new AdminViewModel();
        var adminInfoResult = await _authService.InstitutionAdminInfoAsync();
        
        if (adminInfoResult.IsSuccess) model = adminInfoResult.Value;
        return View(model);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdminInfo(AdminViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var addResult = await _authService.UpdateInstitutionAdminInfoAsync(model);

        if (addResult.IsSuccess)
        {
            await _notificationHelper.NotifyAsync(message: "Update Successfully");
            return View(addResult.Value);
        }

        await _notificationHelper.NotifyAsync(NotificationType.Error, addResult.Errors.First().Message);
        return View(model);
    }
    public async Task<IActionResult> InstitutionList()
    {
        var institueList = await _institutionService.InstitutionListAsync();
        return View(institueList.Value);
    }
    [HttpGet]
    public async Task<IActionResult> CreateInstitutionInfo()
    {

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateInstitutionInfo(InstitutionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // If ModelState is not valid, return to the view with validation errors
            return View(model);
        }

        var createInstitution = await _institutionService.CreateInstitutionInfoAsync(model);

        if (createInstitution != null && createInstitution.IsSuccess)
        {
            await _notificationHelper.NotifyAsync(message: "Created Successfully");
            // return View(createInstitution.Value);
            return RedirectToAction(nameof(InstitutionList));
        }

        await _notificationHelper.NotifyAsync(NotificationType.Error, createInstitution.Errors.First().Message);
        return View(model);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var institution = await _institutionService.GetInstitutionInfoByIdAsync(id);

        if (institution == null)
        {
            // Handle not found scenario, for example, redirect to Index
            return View();
        }

        //var viewModel = _mapper.Map<InstitutionViewModel>(institution);
        return View(institution.Value);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, InstitutionViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var addResult = await _institutionService.EditInstitutionInfoAsync(id,model);

        if (addResult != null && addResult.IsSuccess)
        {
            await _notificationHelper.NotifyAsync(message: "Update Successfully");
            return RedirectToAction(nameof(InstitutionList));
        }

        await _notificationHelper.NotifyAsync(NotificationType.Error, addResult.Errors.First().Message);
        return View(model);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var institution = await _institutionService.GetInstitutionInfoByIdAsync(id);

        if (institution == null)
        {
            // Handle not found scenario, for example, redirect to Index
            return RedirectToAction("Index");
        }

        return View(institution.Value);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _institutionService.DeleteInstitutionInfoAsync(id);

        if (!result.IsSuccess)
        {
            // If deletion fails, handle the error, for example, display an error message
            await _notificationHelper.NotifyAsync(NotificationType.Error, result.Errors.First().Message);
            return View(); // Redirect to the delete view again to show the error message
        }

        return RedirectToAction("InstitutionList"); // Redirect to the index page after successful deletion
    }


    public async Task<IActionResult> InstitutionInfo()
    {

        //await  _notificationHelper.NotifyAsync();

        var model = new InstitutionViewModel();
        var institutionInfo = await _institutionService.GetInstitutionInfoAsync();

        if (institutionInfo.IsSuccess) model = institutionInfo.Value;
        return View(model);
    }
    
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InstitutionInfo(InstitutionViewModel model)
    {
       if (!ModelState.IsValid) return View(model);

        var addResult = await _institutionService.UpdateInstitutionInfoAsync(model);

        if (addResult != null && addResult.IsSuccess)
        {
            await  _notificationHelper.NotifyAsync(message:"Update Successfully");
            return View(addResult.Value);
        }

        await _notificationHelper.NotifyAsync(NotificationType.Error, addResult.Errors.First().Message);
        return View(model);
    }


    // GET
    public IActionResult Dashboard()
    {
        return View();
    }


    // GET
    public async Task<IActionResult> Teacher()
    {
        var model = new List<TeacherModel>();
        var teacherResult = await _teacherService.TeacherListAsync();
        
        if (teacherResult.IsSuccess) model = teacherResult.Value;
      
        return View(model);
        
    }
    public async Task<IActionResult> Details(int id)
    {
        if (id == null )
        {
            return NotFound();
        }
        var teacherDetails = await _teacherService.TeacherDetailsAsync(id);

        return View(teacherDetails.Value);

    }
    // GET
    public async Task<IActionResult> TeacherAssign()
    {
        var getTeachersResult = await _teacherService.TeacherListAsync();

        var teachers = getTeachersResult.ValueOrDefault;

        var getClassResult = await _institutionClassService.ClassListAsync();

        var classes = getClassResult.ValueOrDefault;

        var getCoursesResult = await _institutionCourseService.CourseListAsync();

        var courses = getCoursesResult.ValueOrDefault;

        ViewBag.teachers = new SelectList(teachers, "InstitutionTeacherId", "FirstName");
        ViewBag.Classes = new SelectList(classes, "InstitutionClassId", "ClassName");
        ViewBag.Courses = new SelectList(courses, "InstitutionCourseId", "CourseName");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TeacherAssign(TeacherAssignCourseModel model)
    {
        var getTeachersResult = await _teacherService.TeacherListAsync();

        var teachers = getTeachersResult.ValueOrDefault;

        var getClassResult = await _institutionClassService.ClassListAsync();

        var classes = getClassResult.ValueOrDefault;

        var getCoursesResult = await _institutionCourseService.CourseListAsync();

        var courses = getCoursesResult.ValueOrDefault;

        ViewBag.teachers = new SelectList(teachers, "InstitutionTeacherId", "FirstName");
        ViewBag.Classes = new SelectList(classes, "InstitutionClassId", "ClassName");
        ViewBag.Courses = new SelectList(courses, "InstitutionCourseId", "CourseName");

        if (!ModelState.IsValid) return View(model);

        var addResult = await _teacherService.TeacherAssignCourseAsync(model);

        if (addResult.IsSuccess)
        {
            return RedirectToAction("TeacherAssign");
        }

        ModelState.AddModelError("InstitutionTeacherId", addResult.Errors.First().Message);
        return View(model);
    }

    // GET
    public async Task<IActionResult> TeacherAddContent()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> Course()
    {
        var model = new List<TeacherCourseViewModel>();
        var teacherResult = await _teacherService.TeacherAssignCourseListAsync();

        if (teacherResult.IsSuccess) model = teacherResult.Value;

        return View(model);
     
    }

    // GET
    public IActionResult CourseOffline()
    {
        return View();
    }
    
    // GET
    public IActionResult CourseAssignment()
    {
        return View();
    }
    
    // GET
    public IActionResult CourseOutline()
    {
        return View();
    }
    
    // GET
    public IActionResult CourseTest()
    {
        return View();
    }
   
    // GET
    public IActionResult CourseQuiz()
    {
        return View();
    }
    
    // GET
    public IActionResult CourseGrade()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> Student()
    {
        var model = new List<StudentViewModel>();
        var teacherResult = await _studentService.StudentListAsync();

        if (teacherResult.IsSuccess) model = teacherResult.Value;

        return View(model);
    }

    // GET
    public IActionResult StudentAttendanceReport()
    {
        return View();
    }

    // GET
    public IActionResult StudentClassWise()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> StudentPayment()
    {
        var model = new List<StudentViewModel>();
        var teacherResult = await _studentService.StudentListAsync();

        if (teacherResult.IsSuccess) model = teacherResult.Value;

        return View(model);
    }
    // GET
    public IActionResult StudentSubjectWise()
    {
        return View();
    }
    // GET
    public IActionResult Inbox()
    {
        return View();
    }
    
    // GET
    public IActionResult Routine()
    {
        return View();
    }

    // GET
    public IActionResult Calender()
    {
        return View();
    }

    // GET
    public IActionResult Help()
    {
        return View();
    }  
    
    // GET
    public IActionResult StudentCertificate()
    {
        return View();
    }
}