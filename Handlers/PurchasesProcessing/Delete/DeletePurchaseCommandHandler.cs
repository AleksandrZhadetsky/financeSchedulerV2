using AutoMapper;
using Domain.DTOs;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Delete
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, CommandResponse<PurchaseDTO>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public DeletePurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseDTO>> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            await service.DeletePurchaseAsync(request.Id, cancellationToken);

            return new CommandResponse<PurchaseDTO>(default(PurchaseDTO), "Purchase item deletet successfully.");
        }
    }
}
