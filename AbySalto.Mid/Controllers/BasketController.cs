using AbySalto.Mid.Application.Commands;
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
    }
}
