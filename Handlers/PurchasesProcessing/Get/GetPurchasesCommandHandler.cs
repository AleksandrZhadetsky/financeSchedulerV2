using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchasesCommandHandler : IRequestHandler<GetPurchasesQuery, CommandResponse<IEnumerable<PurchaseModel>>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public GetPurchasesCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<IEnumerable<PurchaseModel>>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
        {
            var purchases = await service.GetPurchasesAsync();
            var purchaseModels = purchases.Select(purchase => mapper.Map<Purchase, PurchaseModel>(purchase)).ToArray();
            var response = new CommandResponse<IEnumerable<PurchaseModel>>(purchaseModels, "Purchases were retrieved successfully.");

            return response;
        }
    }
}
