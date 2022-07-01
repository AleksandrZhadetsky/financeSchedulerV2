using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Delete
{
    public class DeleteCategoryCommand : IRequest<CommandResponse<CategoryModel>>
    {
        public string Id { get; set; }
    }
}
