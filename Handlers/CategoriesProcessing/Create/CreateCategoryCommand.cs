using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Create
{
    public class CreateCategoryCommand : IRequest<CommandResponse<CategoryDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
