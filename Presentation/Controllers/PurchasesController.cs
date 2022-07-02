using Handlers.PurchasesProcessing.Create;
using Handlers.PurchasesProcessing.Delete;
using Handlers.PurchasesProcessing.Get;
using Handlers.PurchasesProcessing.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceSchedulerDemo.Controllers
{
    [Authorize(Roles = "user")]
    [Route("purchases")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PurchasesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePurchaseAsync(CreatePurchaseCommand command, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Created("", response);
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetPurchaseAsync(GetPurchaseQuery query, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(query, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPost]
        [Route("getAll")]
        public async Task<IActionResult> GetPurchasesAsync(CancellationToken cancellationToken)
        {
            var query = new GetPurchasesQuery();
            var response = await mediator.Send(query, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePurchaseAsync(UpdatePurchaseCommand command, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePurchaseAsync(DeletePurchaseCommand command, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
