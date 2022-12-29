using POS.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesParameters : RequestParameter
    {
        public string? Name { get; set; }
    }
}
