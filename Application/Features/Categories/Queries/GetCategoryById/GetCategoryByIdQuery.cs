using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.DTOs;
using POS.Application.Interfaces;
using POS.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryDto>>
    {
        public int CategoryId { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDto>>
        {
            private readonly IRepositoryAsync<Category> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = await _repositoryAsync.GetByIdAsync(request.CategoryId);
                if (category == null || category.IsDeleted == true)
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.CategoryId}");
                else
                {
                    var dto = _mapper.Map<CategoryDto>(category);
                    return new Response<CategoryDto>(dto);
                }
            }
        }
    }
}
