using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;
using NetCoreBase.Application.Features.Items.Queries.GetAllItems;
using NetCoreBase.Application.Features.Items.Commands.AddItem;
using NetCoreBase.Application.Features.Items.Commands.UpdateItem;
using NetCoreBase.Application.Features.Items.Commands.DeleteItem;
using NetCoreBase.Application.Features.Items.Queries.GetPagedItems;
using Asp.Versioning;

namespace NetCoreBase.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/items")]
    [ApiController]
    //[Route("[controller]")]
    //[Route("items")]
    public class ItemController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IValidator<GetItemByIdRequest> _validatorGetItem;
        private readonly IValidator<AddItemRequest> _validatorAddItem;
        private readonly IValidator<UpdateItemRequest> _validatorUpdateItem;
        private readonly IValidator<DeleteItemRequest> _validatorDeleteItem;
        private readonly IValidator<GetPagedItemsRequest> _validatorGetPagedItems;

        public ItemController(IMediator mediator,
            IValidator<GetItemByIdRequest> validator,
            IValidator<AddItemRequest> validatorAddItem,
            IValidator<UpdateItemRequest> validatorUpdateItem,
            IValidator<DeleteItemRequest> validatorDeleteItem,
            IValidator<GetPagedItemsRequest> validatorGetPagedItems)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _validatorGetItem = validator ?? throw new ArgumentNullException(nameof(validator));
            _validatorAddItem = validatorAddItem ?? throw new ArgumentNullException(nameof(validatorAddItem));
            _validatorUpdateItem = validatorUpdateItem ?? throw new ArgumentNullException(nameof(validatorUpdateItem));
            _validatorDeleteItem = validatorDeleteItem ?? throw new ArgumentNullException(nameof(validatorDeleteItem));
            _validatorGetPagedItems = validatorGetPagedItems ?? throw new ArgumentNullException(nameof(validatorGetPagedItems));
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllItemsRequest();
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [MapToApiVersion(2)]
        [HttpGet]
        public async Task<IActionResult> IndexV2()
        {
            var query = new GetAllItemsRequest();
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var query = new GetItemByIdRequest { Id = id };
            var validationResult = await _validatorGetItem.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemRequest request)
        {
            var validationResult = await _validatorAddItem.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var item = await _mediator.Send(request);
            return CreatedAtAction(nameof(Index), new { id = item.Id }, item);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateItemRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the request body.");
            }
            var validationResult = await _validatorUpdateItem.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var item = await _mediator.Send(request);
            return CreatedAtAction(nameof(Index), new { id = item.Id }, item);
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteItemRequest { Id = id };
            var validationResult = await _validatorDeleteItem.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _mediator.Send(request);
            if (!response.IsDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] GetPagedItemsRequest request)
        {
            var validationResult = await _validatorGetPagedItems.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
