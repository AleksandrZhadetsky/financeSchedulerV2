using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Delete
{
    public class DeleteCategoryCommand : IRequest<CommandResponse<CategoryDTO>>
    {
        public string Id { get; set; }
    }
}
