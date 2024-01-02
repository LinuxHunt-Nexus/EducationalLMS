using LearningManagement.Data.Enums;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace LearningManagement.Web.Helper;

public class NotificationHelper
{
    private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NotificationHelperModel _notification;
    public NotificationHelper(ITempDataDictionaryFactory tempDataDictionaryFactory, IHttpContextAccessor httpContextAccessor)
    {
        _tempDataDictionaryFactory = tempDataDictionaryFactory;
        _httpContextAccessor = httpContextAccessor;
        _notification = new NotificationHelperModel();
    }

    public async Task NotifyAsync(NotificationType type = NotificationType.Success, string message = "Success")
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);

        // use tempData as usual
        // tempData["Foo"] = "Bar";
        _notification.Type = type;
        _notification.Message = message;

        tempData["responseKey"] = JsonConvert.SerializeObject(_notification);
    }
}

[JsonObject(MemberSerialization.OptIn)]
public class NotificationHelperModel
{
    public NotificationHelperModel()
    {
        
    }
    public NotificationHelperModel(NotificationType type = NotificationType.Success, string message = "Success")
    {
        Message = message;
        Type = type;
    }
    [JsonProperty(PropertyName = "type")]
    public NotificationType Type { get; set; }
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }
}