using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Get
{
    public class GetCategoriesQuery: IRequest<CommandResponse<IEnumerable<CategoryModel>>>
    {
    }
}
