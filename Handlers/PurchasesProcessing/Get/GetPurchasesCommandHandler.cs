using AutoMapper;
using Domain.DTOs;
using Domain.Entities.Categories;
using Domain.Entities.Purchases;
using Domain.Responses;
using MediatR;
using Services.Categories;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchasesCommandHandler : IRequestHandler<GetPurchasesQuery, CommandResponse<IEnumerable<PurchaseDTO>>>
    {
        private readonly IPurchaseProcessingService _purchaseProcessingService;
        private readonly ICategoryProcessingService _categoryProcessingservice;
        private readonly IMapper mapper;

        public GetPurchasesCommandHandler(IPurchaseProcessingService purchaseProcessingService, ICategoryProcessingService categoryProcessingservice, IMapper mapper)
        {
            this._purchaseProcessingService = purchaseProcessingService;
            this._categoryProcessingservice = categoryProcessingservice;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<IEnumerable<PurchaseDTO>>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseProcessingService.GetPurchasesAsync(cancellationToken);
            var categories = await _categoryProcessingservice.GetCategoriesAsync();
            var purchaseModels = purchases.Select(
                    purchase => {
                        var dto = mapper.Map<Purchase, PurchaseDTO>(purchase);
                        dto.Category =
                            mapper.Map<Category, CategoryDTO>(
                                categories.FirstOrDefault(
                                    category => category.Id.Equals(dto.CategoryId, StringComparison.InvariantCultureIgnoreCase)));

                        return dto;
                    }
                ).ToArray();

            var response = new CommandResponse<IEnumerable<PurchaseDTO>>(purchaseModels, "Purchases were retrieved successfully.");

            return response;
        }
    }
}
