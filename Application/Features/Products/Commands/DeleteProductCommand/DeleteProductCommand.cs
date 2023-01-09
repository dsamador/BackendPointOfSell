
using Domain.Models;
using MediatR;
using POS.Application.Features.Cutomers.Commands.DeleteCustomerCommand;
using POS.Application.Interfaces;
using POS.Application.Wrappers;

namespace POS.Application.Features.Products.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repositoryAsync;

        public DeleteProductCommandHandler(IRepositoryAsync<Product> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.ProductId);
            if (record == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.ProductId}");
            else
            {
                record.IsDeleted = true;
                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.ProductId);
            }
        }
    }
}
