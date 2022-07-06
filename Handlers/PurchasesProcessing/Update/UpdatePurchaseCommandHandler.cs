using AutoMapper;
using Domain.DTOs;
using Domain.Entities.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Update
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, CommandResponse<PurchaseDTO>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public UpdatePurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseDTO>> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = mapper.Map<UpdatePurchaseCommand, Purchase>(request);
            var updatedPurchaseEntity = await service.UpdatePurchaseAsync(purchase, cancellationToken);
            var updatedPurchaseModel = mapper.Map<Purchase, PurchaseDTO>(updatedPurchaseEntity);
            var response = new CommandResponse<PurchaseDTO>(updatedPurchaseModel, "Purchase item updated successfully.");

            return response;
        }
    }
}
