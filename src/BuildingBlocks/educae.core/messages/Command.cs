using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using MediatR;

namespace educae.core.messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
            ValidationResult = new ValidationResult();
        }

        public virtual bool EstaValido()
        {
            return ValidationResult.IsValid;
        }
    }
}