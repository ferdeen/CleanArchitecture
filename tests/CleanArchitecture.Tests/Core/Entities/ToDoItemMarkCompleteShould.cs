using PaxosExercise.Core.Events;
using System.Linq;
using Xunit;

namespace PaxosExercise.Tests.Core.Entities
{
    public class ToDoItemMarkCompleteShould
    {
        [Fact]
        public void SetIsDoneToTrue()
        {
            var item = new MessageItemBuilder().Build();

            item.MarkChanged();

            Assert.True(item.IsDone);
        }

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
