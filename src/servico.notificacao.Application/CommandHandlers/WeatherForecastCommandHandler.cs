using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using servico.notificacao.Application.Commands;
using servico.notificacao.Domain.Exceptions;
using servico.notificacao.Application.Dto;

namespace servico.notificacao.Application.CommandHandlers
{
    public class WeatherForecastCommandHandler : CommandHandler, IRequestHandler<WeatherForecastCommand, IEnumerable<WeatherForecastDto>>
    {
        public WeatherForecastCommandHandler(IMediator bus) : base(bus)
        {
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecastDto>> Handle(WeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return Task.FromResult(result);
        }
    }
}
