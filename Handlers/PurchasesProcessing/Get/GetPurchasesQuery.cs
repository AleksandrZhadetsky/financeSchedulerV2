using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.PurchasesProcessing.Get
{
    public class GetPurchasesQuery : IRequest<CommandResponse<IEnumerable<PurchaseModel>>>
    {
    }
}
