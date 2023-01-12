using AutoMapper;
using Domain.Models;
using POS.Application.DTOs;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;
using POS.Application.Features.Cutomers.Commands.CreateCustomerCommand;
using POS.Application.Features.Products.Commands.CreateProductCommand;

namespace POS.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTO's
            CreateMap<Category, CategoryDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            #endregion

            #region Commands
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<CreateProductCommand, Product>();
            #endregion

        }
    }
}
