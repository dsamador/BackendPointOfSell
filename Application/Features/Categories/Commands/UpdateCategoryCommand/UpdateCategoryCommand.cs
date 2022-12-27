using AutoMapper;
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

namespace POS.Application.Features.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<Response<int>>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Category> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.CategoryId);
            if(record == null || record.IsDeleted == true)            
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.CategoryId}");
            else
            {
                record.Name = request.Name;
                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.CategoryId);
            }            
        }
    }
}
