using PaxosExercise.Core.Events;
using System.Linq;
using Xunit;

namespace PaxosExercise.Tests.Core.Entities
{
    public class MessageItemMarkChangedShould
    {
        [Fact]
        public void RaiseToDoItemCompletedEvent()
        {
            var item = new MessageItemBuilder().Build();

            item.MarkChanged();

            Assert.Single(item.Events);
            Assert.IsType<MessageItemChangedEvent>(item.Events.First());
        }
    }
}
