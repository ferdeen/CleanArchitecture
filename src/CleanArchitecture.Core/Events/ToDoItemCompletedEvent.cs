using PaxosExercise.Core.Entities;
using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Core.Events
{
    public class MessageItemChangedEvent : BaseDomainEvent
    {
        public MessageItem ChangedItem { get; set; }

        public MessageItemChangedEvent(MessageItem changedItem)
        {
            ChangedItem = changedItem;
        }
    }
}