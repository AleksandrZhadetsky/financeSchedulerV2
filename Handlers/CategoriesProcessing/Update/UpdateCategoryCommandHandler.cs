using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<UpdateCategoryCommand, Category>(request);
            var updatedCategoryEntity = await service.UpdateCategoryAsync(category, cancellationToken);
            var updatedCategoryModel = mapper.Map<Category, CategoryModel>(updatedCategoryEntity);
            var response = new CommandResponse<CategoryModel>(updatedCategoryModel, "Category item updated successfully.");

            return response;
        }
    }
}
