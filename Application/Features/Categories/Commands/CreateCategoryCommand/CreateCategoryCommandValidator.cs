using FluentValidation;


namespace POS.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(c => c.Name)
                .MaximumLength(40)
                .WithMessage("La {PropertyName} no puede exeder de 40 caracteres")
                .NotEmpty()
                .WithMessage("La {PropertyName} no puede quedar vacía")
                .NotNull()
                .WithMessage("La {PropertyName} no puede ser nula");
        }
    }
}
