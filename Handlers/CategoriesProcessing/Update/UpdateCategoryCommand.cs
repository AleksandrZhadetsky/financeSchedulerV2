using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Update
{
    public class UpdateCategoryCommand : IRequest<CommandResponse<CategoryDTO>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
