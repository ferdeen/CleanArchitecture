using PaxosExercise.Core.SharedKernel;

namespace PaxosExercise.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}