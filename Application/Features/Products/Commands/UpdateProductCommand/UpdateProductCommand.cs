using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }        
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepositoryAsync<Product> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.ProductId);
            if (record == null || record.IsDeleted == true)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.ProductId}");
            else
            {
                record.Name = request.Name;
                record.Color = request.Color;
                record.SafetyStockLevel = request.SafetyStockLevel;
                record.Stock = request.Stock;
                record.CategoryId = request.CategoryId;                

                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.ProductId);
            }
        }
    }
}
