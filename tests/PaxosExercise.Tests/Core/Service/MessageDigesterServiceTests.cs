using FluentAssertions;
using PaxosExercise.Core.Interfaces;
using PaxosExercise.Core.Services;
using System.Threading.Tasks;
using Xunit;

namespace PaxosExercise.Tests.Core.Service
{
    public class MessageDigesterServiceTests
    {
        private readonly IMessageDigester messageDigester;

        public MessageDigesterServiceTests()
        {
            this.messageDigester = new MessageDigesterService();
        }

        [Fact]
        public async Task ComputeSHA256DigestHashFromMessage()
        {
            var message = "Paxos";
            var expectedDigest = "7e8bf799c2a5b59b8219d64b225424dce22acaa8ee33b90044ebbe8246644eb8";
            var computedDigest = await this.messageDigester.ComputeMessageDigestAsync(message);
            computedDigest.Should().Be(expectedDigest);
        }
    }
}
