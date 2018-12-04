using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}