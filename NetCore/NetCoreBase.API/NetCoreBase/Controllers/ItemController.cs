using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Queries.GetItemById;
using NetCoreBase.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NetCoreBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var query = new GetItemByIdRequest { Id = id };
            var item = await _mediator.Send(query);
            return Ok(item);
        }
    }
}
