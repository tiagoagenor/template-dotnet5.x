using MediatR;
using Microsoft.AspNetCore.Mvc;
using servico.notificacao.Application.Commands;
using servico.notificacao.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico.notificacao.Api.Controllers
{
    public class EmailController : BaseController
    {
        private readonly IMediator _mediator;
        public EmailController(
            INotificationHandler<ExceptionNotification> notifications,
            IMediator mediator
        ) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost("/email/boas-vindas")]
        public async Task<IActionResult> BoasVindas([FromBody] EmailBoasVindasCommand emailBoasVindasCommand)
        {
            var result = await _mediator.Send(emailBoasVindasCommand);
            return Result(result);
        }
    }
}
