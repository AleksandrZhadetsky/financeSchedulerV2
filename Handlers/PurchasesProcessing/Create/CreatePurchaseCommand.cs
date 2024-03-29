﻿using Domain.DTOs;
using Domain.Responses;
using MediatR;

namespace Handlers.PurchasesProcessing.Create
{
    public class CreatePurchaseCommand : IRequest<CommandResponse<PurchaseDTO>>
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
        public string CreatedById { get; set; }
    }
}
