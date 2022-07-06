using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.PurchasesProcessing.Update
{
    public class UpdatePurchaseCommand : IRequest<CommandResponse<PurchaseDTO>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
    }
}
