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
using NetCoreBase.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetCoreBase.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IValidator<GetItemByIdRequest> _validatorGetItem;
        private readonly IValidator<AddItemRequest> _validatorAddItem;
        private readonly IValidator<UpdateItemRequest> _validatorUpdateItem;
        private readonly IValidator<DeleteItemRequest> _validatorDeleteItem;
        private readonly IValidator<GetPagedItemsRequest> _validatorGetPagedItems;

        private CancellationTokenSource _cts;

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

            _cts = new CancellationTokenSource();
            _cts.CancelAfter(TimeSpan.FromSeconds(30)); // Set a timeout for the operation
                                                       // Use the CancellationToken in your async method
                                                       // For example, if you're making an HTTP request, you can pass the token to the request method
                                                       // var response = await httpClient.GetAsync("https://example.com", cts.Token);
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var query = new GetAllItemsRequest();
            var item = await _mediator.Send(query, _cts.Token);
            return Ok(item);
        }

        [MapToApiVersion(2)]
        [HttpGet]
        public Task<IActionResult> GetItemsWithException()
        {
            // Simulate an exception
            throw new ArithmeticException("MAth exception dummy");
            throw new InvalidOperationException("This is a test exception.", new Exception() 
            {
                //Message = "This is an inner exception.",
                Source = "InnerExceptionSource",
                //StackTrace = "InnerExceptionStackTrace",
                HelpLink = "InnerExceptionHelpLink",
                Data = { { "Key", "Value" } },
                HResult = 12345,
                //TargetSite = typeof(ItemController).GetMethod(nameof(GetItemsWithException)),
                //InnerException = new Exception("This is an inner exception.")
            });
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var query = new GetItemByIdRequest { Id = id };
            var validationResult = await _validatorGetItem.ValidateAsync(query, _cts.Token);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            GetItemByIdResponse item = await _mediator.Send(query);
            if (item is null)
            {
                return NotFound(
                    new OperationResponse<GetItemByIdResponse>()
                    .WarningOperation(item, StatusCodes.Status404NotFound,
                    $"Record not found",
                    $"{typeof(GetItemByIdRequest)} not found")
                    );

            }
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
            return CreatedAtAction(nameof(Index), new { id = item.Id },item);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateItemRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(new OperationResponse<object>().WarningOperation(default,StatusCodes.Status400BadRequest,
                    $"Id {id} doesn't match with {request.Id}"));
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

            var query = new GetItemByIdRequest { Id = id };
            GetItemByIdResponse item = await _mediator.Send(query);
            if (item is null)
            {
                return NotFound(
                    new OperationResponse<GetItemByIdResponse>()
                    .WarningOperation(item, StatusCodes.Status404NotFound,
                    $"Record not found",
                    $"{typeof(GetItemByIdRequest)} not found")
                    );
            }

            var response = await _mediator.Send(request);
            if (!response.IsDeleted)
            {
                return Conflict();
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

            var response = await _mediator.Send(request, _cts.Token);
            return Ok(response);
        }
    }
}
