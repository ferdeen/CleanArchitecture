using PaxosExercise.Core.Events;
using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Core.Entities
{
    public class MessageItem : BaseEntity
    {
        public string Message { get; set; }
        public string Digest { get; set; }
        public bool IsDone { get; private set; }

        public void MarkChanged()
        {
            Events.Add(new MessageItemChangedEvent(this));
        }
    }
}
