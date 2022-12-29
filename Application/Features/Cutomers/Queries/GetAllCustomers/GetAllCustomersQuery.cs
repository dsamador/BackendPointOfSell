using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.DTOs;
using POS.Application.Interfaces;
using POS.Application.Specifications;
using POS.Application.Wrappers;

namespace POS.Application.Features.Cutomers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerDto>>>
        {
            private readonly IRepositoryAsync<Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _repositoryAsync.ListAsync(
                    new PagedCustomersSpecification(
                        request.PageSize, request.PageNumber, 
                        request.FirstName, request.MiddleName,
                        request.FirstLastName, request.SecondLastName,
                        request.Address, request.PhoneNumber,
                        request.Email));
                var customerDto = _mapper.Map<List<CustomerDto>>(customers);

                return new PagedResponse<List<CustomerDto>>(customerDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
