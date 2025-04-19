using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;
using static NetCoreBase.Application.Delegates.AnonymousDelegate;
using static NetCoreBase.Application.Delegates.LambdaDelegate;
using static NetCoreBase.Application.Delegates.MultiCastDelegate;
using static NetCoreBase.Application.Delegates.SingleCastDelegate;
using static NetCoreBase.Application.Delegates.ActionDelegate;
using static NetCoreBase.Application.Delegates.FuncDelegate;
using static NetCoreBase.Application.Delegates.PredicateDelegate;

namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{

    public class AddItemHandler : IRequestHandler<AddItemRequest, AddItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public AddItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<AddItemResponse> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            // Example of using a single cast delegate
            SingleCastDelegateDeclaration singleCastDelegate = SingleCastMethod;
            // Invoke the single cast delegate
            singleCastDelegate("Hello from SingleCastDelegate!");

            // Instantiate the multiucast delegate
            MultiCastDelegateDeclaration multiDelegate = AddIva;
            multiDelegate += AddISR; // Add another method
            multiDelegate += AddProfit;
            // Invoke the delegate
            decimal finalPrice = multiDelegate(request.Price);

            // Invoke action delegate
            Action<string> actionDelegate = ActionDelegateDeclaration;
            actionDelegate("my action delegate message");

            // Define a Func delegate Func<T1, T2, T3, TResult>
            Func<int, int, int, int> funcDelegateDeclaration = FuncDelegateDeclaration;
            // Call the delegate
            int functionDelegateResult = funcDelegateDeclaration(5, 10,4);

            Predicate<int> predicateDelegate = PredicateDelegateDeclaration;
            bool predicateDelegateResult = predicateDelegate(3);
            if (predicateDelegateResult)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            // Example of using a anonymous delegate
            AnonymousDelegateDeclaration anonymousDelegate = delegate (string message)
            {
                Console.WriteLine($"Hello from AnonymousDelegate: {message}");
            };

            // Invoke the lambda delegate
            LambdaDelegateDelegateDeclaration lambdaDelegate = (x, y) => x + y;
            decimal lambdaDelegateResult = lambdaDelegate(5, 10);


            var newItem = _mapper.Map<Item>(request);
            newItem.IsActive = true;
            newItem.CreatedAt = DateTimeOffset.UtcNow;
            newItem.CreatedBy = "system"; // TODO: Get current user
            newItem.Price = finalPrice; 

            await _itemRepository.AddAsync(newItem);

            return _mapper.Map<AddItemResponse>(newItem);
        }

        
    }
}