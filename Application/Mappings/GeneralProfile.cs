﻿using AutoMapper;
using Domain.Models;
using POS.Application.DTOs;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;
using POS.Application.Features.Cutomers.Commands;

namespace POS.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTO's
            CreateMap<Category, CategoryDto>();
            #endregion

            #region Commands
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion

        }
    }
}
