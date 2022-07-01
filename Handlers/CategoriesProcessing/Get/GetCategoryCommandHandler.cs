using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Get
{
    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryQuery, CommandResponse<CategoryModel>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public GetCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await service.GetCategoryAsync(request.CategoryId, cancellationToken);
            var categoryModel = mapper.Map<Category, CategoryModel>(category);
            var response = new CommandResponse<CategoryModel>(categoryModel, "Category item retrieved successfully.");

            return response;
        }
    }
}
