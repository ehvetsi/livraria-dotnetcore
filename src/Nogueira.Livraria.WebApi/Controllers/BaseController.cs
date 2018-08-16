using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System.Linq;

namespace Nogueira.Livraria.WebApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificationHandler handler;
        private readonly INotificationObserver observer;

        public BaseController(INotificationHandler handler, INotificationObserver observer)
        {
            this.handler = handler;
            this.observer = observer;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ValidateNotifications(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            observer.Subscribe(handler);
            base.OnActionExecuting(context);
        }

        private void ValidateNotifications(ActionExecutedContext context)
        {
            if (observer.Notification.Notifications.Any())
            {
                var notifications = JsonConvert.SerializeObject(observer.Notification.Notifications);
                context.Result = base.StatusCode(400, notifications);
            }
            observer.Dispose();
            base.OnActionExecuted(context);
        }
    }
}