using AutoMapper;
using Domain.Models;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateCategoryCommand, Category>();
            #endregion
        }
    }
}
