using FluentValidation;
using servico.notificacao.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servico.notificacao.Application.Validations
{
    class EmailBoasVindasValidation : AbstractValidator<EmailBoasVindasCommand>
    {
        public EmailBoasVindasValidation()
        {
            ValidateNome();
            ValidateEmail();
        }

        private void ValidateNome()
        {
            RuleFor(boasVindas => boasVindas.Nome).NotEmpty();
        }

        private void ValidateEmail()
        {
            RuleFor(boasVindas => boasVindas.Email).NotEmpty().EmailAddress();
        }
    }
}
