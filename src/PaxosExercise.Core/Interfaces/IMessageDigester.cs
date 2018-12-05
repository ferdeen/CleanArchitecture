using System.Threading;
using System.Threading.Tasks;

namespace PaxosExercise.Core.Interfaces
{
    public interface IMessageDigester
    {
        Task<string> ComputeMessageDigestAsync(string message, CancellationToken cancellationToken = default(CancellationToken));
    }
}
