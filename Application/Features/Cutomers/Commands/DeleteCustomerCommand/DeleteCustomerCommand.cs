using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;


namespace POS.Application.Features.Cutomers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;

        public DeleteCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.CustomerId);
            if (record == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.CustomerId}");
            else
            {
                record.IsDeleted = true;
                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.CustomerId);
            }
        }
    }
}
