using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<CreateCategoryCommand, Category>(request);

            try
            {
                var createdCategory = await service.CreateCategoryAsync(category, cancellationToken);
                var categoryModel = mapper.Map<Category, CategoryModel>(createdCategory);
                var response = new CommandResponse<CategoryModel>(categoryModel, "Category item created successfully.");

                return response;
            }
            catch (Exception e)
            {
                return new CommandResponse<CategoryModel>($"Category creation failed. Reason: {e.Message}");
            }
        }
    }
}
