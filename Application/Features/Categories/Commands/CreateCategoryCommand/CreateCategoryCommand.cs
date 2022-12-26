using AutoMapper;
using Domain.Models;
using MediatR;
using POS.Application.Interfaces;
using POS.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand: IRequest<Response<int>>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Category> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Category>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
