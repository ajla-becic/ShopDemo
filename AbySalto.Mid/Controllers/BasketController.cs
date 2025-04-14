using AbySalto.Mid.Application.Commands;
using AbySalto.Mid.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] AddToBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket([FromQuery] int userId)
        {
            var result = await _mediator.Send(new GetBasketQuery { UserId = userId });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
