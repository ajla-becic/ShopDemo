using AbySalto.Mid.Application.Commands;
using AbySalto.Mid.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.Controllers
{
    [Route("api/product")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] bool sortDesc = false)
        {
            var query = new GetProductsQuery
            {
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortDesc = sortDesc
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("add-favorite")]
        public async Task<IActionResult> AddToFavorites([FromBody] AddToFavoritesCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
