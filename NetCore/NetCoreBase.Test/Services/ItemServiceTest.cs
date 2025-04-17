using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Test.Services
{
    public class ItemServiceTest : IClassFixture<TestFixture>//, IAsyncLifetime
    {
        private readonly IItemRepository _repository;

        private long _id;

        public ItemServiceTest(TestFixture fixture)
        {
            _repository = fixture.ServiceProvider.GetRequiredService<IItemRepository>();
        }

        [Fact]
        public async Task GetAllItems()
        {
            Expression<Func<Item, bool>> predicate = item => item.IsActive && item.Price > 0;
            var items = await _repository.GetAllAsyncAsNoTracking(predicate, default);
            Assert.NotNull(items);
        }

        [Fact]
        public async Task GetAnItemAsyncNoTracking()
        {
            var items = await _repository.GetByIdAsyncNoTracking(1, default);
            Assert.NotNull(items);
        }


        [Fact]
        public async Task CreateAnItemsAndDelete()
        {
            var newItem = new Item()
            {
                Name = "Test Item",
                Description = "Test Description",
                Price = 10.99m
            };
            newItem.IsActive = true;
            newItem.CreatedAt = DateTimeOffset.UtcNow;
            newItem.CreatedBy = "system"; // TODO: Get current user

            var items = await _repository.AddAsync(newItem);
            _id = items.Id;
            Assert.NotNull(items);

            var delete = await _repository.DeleteAsync(_id);
            Assert.True(delete);
        }

        [Fact]
        public async Task UpdateAnItems()
        {
            var itemResult = await _repository.GetByIdAsync(1, default);
            Item item = itemResult;

            item.Name = "Updated Item on tetsing";
            item.Description = "Updated Description on tetsing";
            item.Price = 20.99m;
            item.UpdatedAt = DateTimeOffset.UtcNow;
            item.UpdatedBy = "system-test"; // TODO: Get current user
            var updatedItem = _repository.UpdateAsync(item);
            Assert.NotNull(updatedItem);
        }
    }
}
