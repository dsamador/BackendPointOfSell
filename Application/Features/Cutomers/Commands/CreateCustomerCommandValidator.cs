
using Domain.Models;
using FluentValidation;

namespace POS.Application.Features.Cutomers.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {        
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.MiddleName)                
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(c => c.FirstLastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.SecondLastName)                
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")                
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");
            
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");
        }
    }
}
