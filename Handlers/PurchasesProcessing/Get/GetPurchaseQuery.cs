using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchaseQuery : IRequest<CommandResponse<PurchaseDTO>>
    {
        public string Id { get; set; }
    }
}
