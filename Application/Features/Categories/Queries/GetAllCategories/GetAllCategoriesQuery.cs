using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.DTOs;
using POS.Application.Interfaces;
using POS.Application.Wrappers;


namespace POS.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PagedResponse<List<CategoryDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedResponse<List<CategoryDto>>>
        {
            private readonly IRepositoryAsync<Category> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllCategoriesQueryHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
