using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.PurchasesProcessing.Delete
{
    public class DeletePurchaseCommand : IRequest<CommandResponse<PurchaseDTO>>
    {
        public string Id { get; set; }
    }
}
