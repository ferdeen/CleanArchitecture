using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Linq;
using Xunit;
using PaxosExercise.Infrastructure.Data;
using FluentAssertions;

namespace PaxosExercise.Tests.Integration.Data
{
    public class EfRepositoryShould
    {
        private AppDbContext _dbContext;

        private static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("PaxosExercise")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public void AddItemAndSetId()
        {
            var repository = GetRepository();
            var item = new MessageItemBuilder().Build();

            repository.Add(item);

            var newItem = repository.List<MessageItem>().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void UpdateItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialMessage = Guid.NewGuid().ToString();
            var item = new MessageItemBuilder().Message(initialMessage).Build();

            repository.Add(item);

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.List<MessageItem>()
                .FirstOrDefault(i => i.Message == initialMessage);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newMessage = Guid.NewGuid().ToString();
            newItem.Message = newMessage;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.List<MessageItem>()
                .FirstOrDefault(i => i.Message == newMessage);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Message, updatedItem.Message);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialMessage = Guid.NewGuid().ToString();
            var item = new MessageItemBuilder().Message(initialMessage).Build();
            repository.Add(item);

            // delete the item
            repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(repository.List<MessageItem>(),
                i => i.Message == initialMessage);
        }

        [Fact]
        public void DeleteAllAfterAdding()
        {
            // add an item
            var repository = GetRepository();
            var initialMessage = Guid.NewGuid().ToString();

            var item = new MessageItemBuilder().Message(initialMessage).Build();
            repository.Add(item);

            item = new MessageItemBuilder().Message(initialMessage).Build();
            repository.Add(item);

            repository.List<MessageItem>().Should().HaveCount(2);

            repository.DeleteAll<MessageItem>();

            repository.List<MessageItem>().Should().BeEmpty();
        }

        private EfRepository GetRepository()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();

            _dbContext = new AppDbContext(options, mockDispatcher.Object);
            return new EfRepository(_dbContext);
        }
    }
}
