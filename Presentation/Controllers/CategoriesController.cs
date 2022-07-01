using Handlers.CategoriesProcessing.Create;
using Handlers.CategoriesProcessing.Delete;
using Handlers.CategoriesProcessing.Get;
using Handlers.CategoriesProcessing.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceSchedulerDemo.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="mediator"> Instance of <see cref="IMediator"/>. </param>
        public CategoriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Created("", response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCategoryAsync(GetCategoryQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery();
            var response = await _mediator.Send(query, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCategoryAsync(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
