using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Get
{
    /// <summary>
    /// Handler for retrieving categories.
    /// </summary>
    public class GetCategoriesCommandHandler : IRequestHandler<GetCategoriesQuery, CommandResponse<IEnumerable<CategoryModel>>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public GetCategoriesCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<IEnumerable<CategoryModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await service.GetCategoriesAsync();
            var presentationCategories = categories.Select(category => mapper.Map<Category, CategoryModel>(category)).ToArray();
            var response = new CommandResponse<IEnumerable<CategoryModel>>(presentationCategories, "Categories were retrieved successfully.");

            return response;
        }
    }
}
