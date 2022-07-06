using AutoMapper;
using Domain.Entities.Categories;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CommandResponse<CategoryDTO>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<UpdateCategoryCommand, Category>(request);
            var updatedCategoryEntity = await service.UpdateCategoryAsync(category, cancellationToken);
            var updatedCategoryModel = mapper.Map<Category, CategoryDTO>(updatedCategoryEntity);
            var response = new CommandResponse<CategoryDTO>(updatedCategoryModel, "Category item updated successfully.");

            return response;
        }
    }
}
