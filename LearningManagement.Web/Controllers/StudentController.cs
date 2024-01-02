using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearningManagement.Web.Controllers;
[Authorize(Roles = "Student")]
public class StudentController : Controller
{
    // GET
    public IActionResult Dashboard()
    {
        return View();
    }
}