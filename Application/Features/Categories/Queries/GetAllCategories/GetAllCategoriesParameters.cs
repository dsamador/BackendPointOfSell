using POS.Application.Parameters;

namespace POS.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesParameters : RequestParameter
    {
        public string? Name { get; set; }
    }
}
