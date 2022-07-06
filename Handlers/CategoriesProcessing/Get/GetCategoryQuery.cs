using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.CategoriesProcessing.Get
{
    public class GetCategoryQuery : IRequest<CommandResponse<CategoryDTO>>
    {
        public string CategoryId { get; set; }
    }
}
