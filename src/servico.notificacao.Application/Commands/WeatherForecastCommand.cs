using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servico.notificacao.Application.Dto;

namespace servico.notificacao.Application.Commands
{
    public class WeatherForecastCommand : Command, IRequest<IEnumerable<WeatherForecastDto>>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
