using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;

namespace NetCoreBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IValidator<GetItemByIdRequest> _validator;

        public ItemController(IMediator mediator,
            IValidator<GetItemByIdRequest> validator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var query = new GetItemByIdRequest { Id = id };
            var validationResult = await _validator.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var item = await _mediator.Send(query);
            return Ok(item);
        }
    }
}
