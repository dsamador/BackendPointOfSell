using FluentValidation;


namespace POS.Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.Color)
                    .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(c => c.SafetyStockLevel)
                    .NotNull().WithMessage("La {PropertyName} no puede ser nula");

            RuleFor(c => c.Stock)
                    .NotNull().WithMessage("La {PropertyName} no puede ser nula")
                    .GreaterThan(-1).WithMessage("El {PropertyName} no puede ser 0 o menor a 0");
        }
        
    }
}
