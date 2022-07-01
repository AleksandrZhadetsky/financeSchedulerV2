using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchaseCommandHandler : IRequestHandler<GetPurchaseQuery, CommandResponse<PurchaseModel>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public GetPurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchase = await service.GetPurchaseAsync(request.Id);
            var purchaseModel = mapper.Map<Purchase, PurchaseModel>(purchase);
            var response = new CommandResponse<PurchaseModel>(purchaseModel, "Purchase item retrieved successfully.");

            return response;
        }
    }
}
