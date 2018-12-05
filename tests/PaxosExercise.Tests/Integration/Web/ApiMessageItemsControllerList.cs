using PaxosExercise.Core.Entities;
using PaxosExercise.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using PaxosExercise.Web.Utilities.JsonErrors;
using System.Net;
using PaxosExercise.Web.ApiModels;

namespace PaxosExercise.Tests.Integration.Web
{

    public class ApiMessageItemsControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string MessageRouteApi = "/api/messages/";
        private const string GetMessagesAction = "getmessages";
        private const string FlushMessagesAction = "flushmessages";

        public ApiMessageItemsControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnStoreSeedItems()
        {
            var response = await _client.GetAsync($"{MessageRouteApi}{GetMessagesAction}");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<MessageItem>>(stringResponse).ToList();

            result.Count.Should().Be(SeedData.Messages.Count());
            result.Count(a => a.Message == SeedData.Messages.First().Message).Should().Be(1);
            result.Count(a => a.Message == SeedData.Messages.Last().Message).Should().Be(1);
        }

        [Fact]
        public async Task PostMessageReturnsSuccessfulDigest()
        {
            var result = await PostNewMessageAsync(SeedData.Messages.First());
            result.Digest.Contains(SeedData.Messages.First().Digest);
        }

        [Fact]
        public async Task FlushMessages()
        {
            // At setup there are two messages in the repository.  Remove both.
            var response = await _client.GetAsync($"{MessageRouteApi}{FlushMessagesAction}");
            response.EnsureSuccessStatusCode();

            response = await _client.GetAsync($"{MessageRouteApi}{GetMessagesAction}");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<MessageItem>>(stringResponse).ToList();

            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task RetrieveDigestFromExistingMessage()
        {
            var searchMessageItem = SeedData.Messages.First();
          
            var response = await _client.GetAsync($"{MessageRouteApi}?digest={searchMessageItem.Digest}");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            stringResponse.Should().Be(searchMessageItem.Message);
        }

        [Fact]
        public async Task RetrieveDigestFromNonExistientMessageThrowsNotFound()
        {
            var dummyDigest = "dummy";
            var response = await _client.GetAsync($"{MessageRouteApi}?digest={dummyDigest}");

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ErrorResponse>(stringResponse);
            result.Errors.Should().NotBeEmpty();

            ErrorModel error = result.Errors[0];

            error.Description.Contains($"'{dummyDigest}' does not exist in the store, please post a message");
            error.Message.Contains("Message not found");
            error.Status.Should().Be((int)HttpStatusCode.NotFound);
        }

        private async Task<MessageItem> PostNewMessageAsync(MessageItem item)
        {
            var json = JsonConvert.SerializeObject(
                new MessageItemDTO()
                {
                    Message = item.Message
                });

            var response = await _client.PostAsync(MessageRouteApi,
                new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();      
            
            return JsonConvert.DeserializeObject<MessageItem>(stringResponse); ;
        }
    }
}
