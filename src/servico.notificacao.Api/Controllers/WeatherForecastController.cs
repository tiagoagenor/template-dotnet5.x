using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using servico.notificacao.Domain.Exceptions;
using servico.notificacao.Application.Commands;

namespace servico.notificacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            INotificationHandler<ExceptionNotification> notifications,
            IMediator mediator,
            ILogger<WeatherForecastController> logger
        ): base(notifications)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new WeatherForecastCommand());
            return Result(result);
        }
    }
}
