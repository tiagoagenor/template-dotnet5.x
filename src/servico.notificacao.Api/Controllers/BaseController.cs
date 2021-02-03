using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using servico.notificacao.Domain.Exceptions;
using MediatR;

namespace servico.notificacao.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ExceptionNotificationHandler _notifications;
        protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

        protected BaseController(INotificationHandler<ExceptionNotification> notifications)
        {
            _notifications = (ExceptionNotificationHandler)notifications;
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected IActionResult Result(object result, int statusCode = 200)
        {
            if (IsValidOperation())
            {
                return StatusCode(statusCode, new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications()
            });
        }

    }
}