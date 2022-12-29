using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.DTOs;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Cutomers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public int CustomerId { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
        {
            private readonly IRepositoryAsync<Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _repositoryAsync.GetByIdAsync(request.CustomerId);
                if (customer == null || customer.IsDeleted == true)
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.CustomerId}");
                else
                {
                    var dto = _mapper.Map<CustomerDto>(customer);
                    return new Response<CustomerDto>(dto);
                }
            }
        }
    }
}
