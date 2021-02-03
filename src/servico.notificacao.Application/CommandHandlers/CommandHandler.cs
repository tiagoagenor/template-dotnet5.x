using MediatR;
using servico.notificacao.Application.Commands;
using servico.notificacao.Domain.Exceptions;

namespace servico.notificacao.Application.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IMediator _bus;
        // private readonly ExceptionNotificationHandler _notifications;

        protected CommandHandler(IMediator bus)
        {
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                _bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }
    }
}