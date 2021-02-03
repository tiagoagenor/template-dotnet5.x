using MediatR;
using servico.notificacao.Application.Commands;
using servico.notificacao.Infra.Proxy.Gmail.src.BoasVindas;
using servico.notificacao.Infra.Proxy.Gmail.src.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace servico.notificacao.Application.CommandHandlers
{
    public class EmailBoasVindasCommandHandler : CommandHandler, IRequestHandler<EmailBoasVindasCommand, bool>
    {
        private readonly IBoasVindasGmail _boasVindasGmail;
        public EmailBoasVindasCommandHandler(
            IMediator bus,
            IBoasVindasGmail boasVindasGmail
        ) : base(bus)
        {
            _boasVindasGmail = boasVindasGmail;
        }

        public async Task<bool> Handle(EmailBoasVindasCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            return await _boasVindasGmail.Enviar(new BoasVindasGmailDto() { 
                Nome = request.Nome,
                Email = request.Email
            });
        }
    }
}
