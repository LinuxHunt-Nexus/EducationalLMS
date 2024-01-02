using LearningManagement.Application.Services;
using LearningManagement.Data.Enums;
using LearningManagement.Data.ViewModels;
using LearningManagement.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace LearningManagement.Web.Controllers;

public class AppAdminController : Controller
{
    private readonly IInstitutionService _institutionService;
    private readonly NotificationHelper _notificationHelper;
    public AppAdminController(IInstitutionService institutionService, NotificationHelper notificationHelper)
    {
        _institutionService = institutionService;
        _notificationHelper = notificationHelper;
    }

    // GET
    public IActionResult Dashboard()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> InstitutionList()
    {
        var model = new List<InstitutionViewModel>();
        var teacherResult = await _institutionService.InstitutionListAsync();

        if (teacherResult.IsSuccess) model = teacherResult.Value;

        return View(model);
    }

    public async Task<IActionResult> InstitutionInfo(int id)
    {

        //await  _notificationHelper.NotifyAsync();

        var model = new InstitutionViewModel();
        var institutionInfo = await _institutionService.GetInstitutionInfoByIdAsync(id);

        if (institutionInfo.IsFailed)
        {
            await _notificationHelper.NotifyAsync(NotificationType.Error, institutionInfo.Errors.First().Message);
            return RedirectToAction("InstitutionList");
        }

        model = institutionInfo.Value;

        return View(model);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InstitutionInfo(InstitutionViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var addResult = await _institutionService.UpdateInstitutionInfoByAdminAsync(model);

        if (addResult.IsSuccess)
        {
            await _notificationHelper.NotifyAsync(message: "Update Successfully");
            //TempData["responseKey"] = new NotificationHelperModel(NotificationType.Success, "Update Successfully");
            return Redirect("~/AppAdmin/InstitutionList");
        }

        await _notificationHelper.NotifyAsync(NotificationType.Error, addResult.Errors.First().Message);
        return View(model);
    }
}