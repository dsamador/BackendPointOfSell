using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithMessage("La {PropertyName} no puede quedar vacía");
        }
    }
}
