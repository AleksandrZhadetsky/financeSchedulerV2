using AutoMapper;
using Domain.Entities.Categories;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Get
{
    /// <summary>
    /// Handler for retrieving categories.
    /// </summary>
    public class GetCategoriesCommandHandler : IRequestHandler<GetCategoriesQuery, CommandResponse<IEnumerable<CategoryDTO>>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public GetCategoriesCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<IEnumerable<CategoryDTO>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await service.GetCategoriesAsync();
            var presentationCategories = categories.Select(category => mapper.Map<Category, CategoryDTO>(category)).ToArray();
            var response = new CommandResponse<IEnumerable<CategoryDTO>>(presentationCategories, "Categories were retrieved successfully.");

            return response;
        }
    }
}
