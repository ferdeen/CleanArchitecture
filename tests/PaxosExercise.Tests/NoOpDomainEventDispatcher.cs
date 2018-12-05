using PaxosExercise.Core.Interfaces;
using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Tests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
