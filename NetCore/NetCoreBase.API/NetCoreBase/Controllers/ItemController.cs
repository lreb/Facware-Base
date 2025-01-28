using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Queries.GetByIdItemHandler;
using NetCoreBase.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static NetCoreBase.Application.Queries.GetByIdItemHandler.ItemGetByIdQuery;

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
            var query = new ItemGetByIdQuery { Id = id };
            var item = await _mediator.Send(query);
            return Ok(item);
        }
    }
}
