using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            var AGEA = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(AGEA);
            services.AddValidatorsFromAssembly(AGEA);
            services.AddMediatR(AGEA);
        }
    }
}
