using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Get
{
    public class GetCategoryQuery : IRequest<CommandResponse<CategoryModel>>
    {
        public string CategoryId { get; set; }
    }
}
