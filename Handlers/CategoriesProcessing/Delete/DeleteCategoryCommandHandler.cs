using AutoMapper;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Categories;

namespace Handlers.CategoriesProcessing.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommandResponse<CategoryDTO>>
    {
        private readonly ICategoryProcessingService service;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(ICategoryProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryDTO>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await service.DeleteCategoryAsync(request.Id, cancellationToken);

            return new CommandResponse<CategoryDTO>(default(CategoryDTO), "Category item deletet successfully.");
        }
    }
}
