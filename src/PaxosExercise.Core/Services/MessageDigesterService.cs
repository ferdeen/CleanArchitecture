using PaxosExercise.Core.Interfaces;
using System;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaxosExercise.Core.Services
{
    /// <summary>
    /// Component that takes a message and converts it into a SHA256 hash digest.
    /// </summary>
    public class MessageDigesterService : IMessageDigester
    {
        /// <inheritdoc />
        public Task<string> ComputeMessageDigestAsync(string message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run<string>(() =>
            {
                StringBuilder builder = new StringBuilder();

                try
                {
                    using (var sha256 = SHA256.Create())
                    {
                        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));

                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }

                    }
                }
                catch (AggregateException e)
                {
                    ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                }

                return builder.ToString();

            }, cancellationToken);
        }
    }
}
