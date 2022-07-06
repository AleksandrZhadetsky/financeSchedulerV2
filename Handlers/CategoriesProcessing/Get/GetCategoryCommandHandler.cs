using AutoMapper;
using Domain.Entities.Categories;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Get
{
    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryQuery, CommandResponse<CategoryDTO>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public GetCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryDTO>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await service.GetCategoryAsync(request.CategoryId, cancellationToken);
            var categoryModel = mapper.Map<Category, CategoryDTO>(category);
            var response = new CommandResponse<CategoryDTO>(categoryModel, "Category item retrieved successfully.");

            return response;
        }
    }
}
