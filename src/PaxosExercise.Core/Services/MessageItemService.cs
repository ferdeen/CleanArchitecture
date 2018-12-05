using Ardalis.GuardClauses;
using PaxosExercise.Core.Events;
using PaxosExercise.Core.Interfaces;

namespace PaxosExercise.Core.Services
{
    public class MessageItemService : IHandle<MessageItemChangedEvent>
    {
        public void Handle(MessageItemChangedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
        }
    }
}
