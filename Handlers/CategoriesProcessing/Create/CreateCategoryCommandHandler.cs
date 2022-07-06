using AutoMapper;
using Domain.Entities.Categories;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommandResponse<CategoryDTO>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<CreateCategoryCommand, Category>(request);

            try
            {
                var createdCategory = await service.CreateCategoryAsync(category, cancellationToken);
                var categoryModel = mapper.Map<Category, CategoryDTO>(createdCategory);
                var response = new CommandResponse<CategoryDTO>(categoryModel, "Category item created successfully.");

                return response;
            }
            catch (Exception e)
            {
                return new CommandResponse<CategoryDTO>($"Category creation failed. Reason: {e.Message}");
            }
        }
    }
}
