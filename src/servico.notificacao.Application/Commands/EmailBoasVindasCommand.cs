using MediatR;
using servico.notificacao.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servico.notificacao.Application.Commands
{
    public class EmailBoasVindasCommand : Command, IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new EmailBoasVindasValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
