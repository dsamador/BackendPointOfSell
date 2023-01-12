using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.DTOs;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDto>>
    {
        public int ProductId { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
        {
            private readonly IRepositoryAsync<Product> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IRepositoryAsync<Product> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var record = await _repositoryAsync.GetByIdAsync(request.ProductId);                

                if (record == null || record.IsDeleted == true)
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.ProductId}");
                else
                {
                    var dto = _mapper.Map<ProductDto>(record);
                    return new Response<ProductDto>(dto);
                }
            }
        }
    }
}
