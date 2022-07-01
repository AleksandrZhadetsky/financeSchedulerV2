using AutoMapper;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Purchases;

namespace Handlers.PurchasesProcessing.Delete
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, CommandResponse<PurchaseModel>>
    {
        private readonly IPurchaseProcessingService service;
        private readonly IMapper mapper;

        public DeletePurchaseCommandHandler(IPurchaseProcessingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            await service.DeletePurchaseAsync(request.Id);

            return new CommandResponse<PurchaseModel>(default(PurchaseModel), "Purchase item deletet successfully.");
        }
    }
}
