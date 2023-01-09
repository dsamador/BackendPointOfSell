using Domain.Models;
using FluentValidation;
using POS.Application.Interfaces;

namespace POS.Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        //private readonly ApplicationDbContext _context;
        //public CreateProductCommandValidator(ApplicationDbContext context)
        public CreateProductCommandValidator()
        {
            //_context = context;

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
        //public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        //{
        //    return await _repositoryAsync.AddAsync(p => p.Name != name, cancellationToken);
        //}
    }
}
