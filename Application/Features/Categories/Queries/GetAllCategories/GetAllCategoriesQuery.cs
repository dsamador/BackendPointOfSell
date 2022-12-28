using MediatR;
using POS.Application.DTOs;
using POS.Application.Wrappers;


namespace POS.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PagedResponse<List<CategoryDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public class GetAllCategoriesQuer
    }
}
