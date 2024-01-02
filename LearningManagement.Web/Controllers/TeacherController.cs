using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearningManagement.Web.Controllers;
[Authorize(Roles = "Teacher")]
public class TeacherController : Controller
{
    // GET
    public IActionResult Dashboard()
    {
        return View();
    }
}