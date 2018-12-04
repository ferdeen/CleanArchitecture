using PaxosExercise.Core.Events;
using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Core.Entities
{
    public class MessageItem : BaseEntity
    {
        public string Message { get; set; }

        public void MarkChanged()
        {
            Events.Add(new MessageItemChangedEvent(this));
        }
    }
}
