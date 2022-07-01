using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Create
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, CommandResponse<PurchaseModel>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public CreatePurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = mapper.Map<CreatePurchaseCommand, Purchase>(request);

            try
            {
                var createdPurchase = await service.CreatePurchaseAsync(purchase);
                var purchaseModel = mapper.Map<Purchase, PurchaseModel>(createdPurchase);
                var response = new CommandResponse<PurchaseModel>(purchaseModel, "Purchase item created successfully.");

                return response;
            }
            catch (System.Exception e)
            {
                return new CommandResponse<PurchaseModel>($"Purchase creation failed. Reason: {e.Message}");
            }
        }
    }
}
