using AutoMapper;
using Domain.DTOs;
using Domain.Entities.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchaseCommandHandler : IRequestHandler<GetPurchaseQuery, CommandResponse<PurchaseDTO>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public GetPurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseDTO>> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchase = await service.GetPurchaseAsync(request.Id, cancellationToken);
            var purchaseModel = mapper.Map<Purchase, PurchaseDTO>(purchase);
            var response = new CommandResponse<PurchaseDTO>(purchaseModel, "Purchase item retrieved successfully.");

            return response;
        }
    }
}
