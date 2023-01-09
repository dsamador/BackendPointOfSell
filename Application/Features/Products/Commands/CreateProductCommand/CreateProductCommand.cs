using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepositoryAsync<Product> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Product>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.ProductId);
        }
    }
}
