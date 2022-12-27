using Domain.Models;
using MediatR;
using POS.Application.Exceptions;
using POS.Application.Interfaces;
using POS.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand:IRequest<Response<int>>
    {
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Category> _repositoryAsync;

        public DeleteCategoryCommandHandler(IRepositoryAsync<Category> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.CategoryId);
            if (record == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.CategoryId}");
            else
            {
                record.IsDeleted = true;
                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.CategoryId);
            }
        }
    }

}
