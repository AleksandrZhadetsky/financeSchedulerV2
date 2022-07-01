using AutoMapper;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await service.DeleteCategoryAsync(request.Id, cancellationToken);

            return new CommandResponse<CategoryModel>(default(CategoryModel), "Category item deletet successfully.");
        }
    }
}
