using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Cutomers.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = null!;
        public string? SecondLastName { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.CustomerId);
            if (record == null || record.IsDeleted == true)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.CustomerId}");
            else
            {
                record.FirstName      = request.FirstName;
                record.MiddleName     = request.MiddleName;
                record.FirstLastName  = request.FirstLastName;
                record.SecondLastName = request.SecondLastName;
                record.Address        = request.Address;
                record.DateOfBirth    = request.DateOfBirth;
                record.PhoneNumber    = request.PhoneNumber;
                record.Email          = request.Email;

                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.CustomerId);
            }
        }
    }
}
