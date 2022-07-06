using AutoMapper;
using Domain.DTOs;
using Domain.Entities.Categories;
using Domain.Entities.Purchases;
using Domain.Responses;
using MediatR;
using Services.Categories;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Create
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, CommandResponse<PurchaseDTO>>
    {
        private readonly IPurchaseProcessingService _purchaseProcessingService;
        private readonly ICategoryProcessingService _categoryProcessingservice;
        private readonly IMapper mapper;

        public CreatePurchaseCommandHandler(IPurchaseProcessingService purchaseProcessingService, ICategoryProcessingService categoryProcessingservice, IMapper mapper)
        {
            this._purchaseProcessingService = purchaseProcessingService;
            this._categoryProcessingservice = categoryProcessingservice;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseDTO>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = mapper.Map<CreatePurchaseCommand, Purchase>(request);

            try
            {
                var createdPurchase = await _purchaseProcessingService.CreatePurchaseAsync(purchase, cancellationToken);
                var category = await _categoryProcessingservice.GetCategoryAsync(createdPurchase.CategoryId, cancellationToken);
                var purchaseDTO = mapper.Map<Purchase, PurchaseDTO>(createdPurchase);
                purchaseDTO.Category = mapper.Map<Category, CategoryDTO>(category);
                var response = new CommandResponse<PurchaseDTO>(purchaseDTO, "Purchase item created successfully.");

                return response;
            }
            catch (System.Exception e)
            {
                return new CommandResponse<PurchaseDTO>($"Purchase creation failed. Reason: {e.Message}");
            }
        }
    }
}
