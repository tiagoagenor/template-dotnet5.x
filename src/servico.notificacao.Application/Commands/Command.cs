using System;
using FluentValidation.Results;

namespace servico.notificacao.Application.Commands
{
    public abstract class Command
    {
        protected ValidationResult ValidationResult { get; set; }

        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }

        public abstract bool IsValid();
    }
}
