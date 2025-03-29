using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.Repositories;

namespace NetCoreBase.Test.Services
{
    public class ItemServiceTest : IClassFixture<TestFixture>
    {
        //private readonly ServiceProvider _serviceProvider;

        private readonly IItemRepository _repository;

        public ItemServiceTest(TestFixture fixture)
        {
            _repository = fixture.ServiceProvider.GetRequiredService<IItemRepository>();
        }

        [Fact]
        public void GetAllItems()
        {
            var items = _repository.GetAllAsync(new CancellationToken());
            Assert.NotNull(items);
        }
    }
}
