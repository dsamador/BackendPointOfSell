using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;


namespace POS.Application.Features.Cutomers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = null!;
        public string? SecondLastName { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.CustomerId);
        }
    }
}
