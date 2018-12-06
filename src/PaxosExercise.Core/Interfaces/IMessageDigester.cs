using System.Threading;
using System.Threading.Tasks;

namespace PaxosExercise.Core.Interfaces
{
    public interface IMessageDigester
    {
        /// <summary>
        /// Converts a message into a SHA256 Hash.
        /// </summary>
        /// <param name="message"> Message text that's being converted into a hash.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> Notify a cancellation of the task.</param>
        /// <returns>A <see cref="GetColdStakingInfoResponse"/> object containing the cold staking information.</returns>
        Task<string> ComputeMessageDigestAsync(string message, CancellationToken cancellationToken = default(CancellationToken));
    }
}
