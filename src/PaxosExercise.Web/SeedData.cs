using PaxosExercise.Core.Entities;
using PaxosExercise.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace PaxosExercise.Web
{
    public static class SeedData
    {
        public static IEnumerable<MessageItem> Messages;

        public static void PopulateTestData(AppDbContext dbContext)
        {
            if (Messages == null)
            {
                Messages = GetMessages();
            }

            var messages = dbContext.MessageItems;
            foreach (var item in messages)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            foreach (var item in Messages)
            {
                dbContext.MessageItems.Add(item);
            }

            dbContext.SaveChanges();
        }

        private static IEnumerable<MessageItem> GetMessages()
        {
            return new List<MessageItem>()
            {
                new MessageItem()
                {
                    Message = "Ferdeen",
                    Digest = "94614313b6ab9fc78ff632295ebeb5a4ab993316f6ba0392ceb7811fc4da4435"
                },
                new MessageItem()
                {
                    Message = "Paxos",
                    Digest = "7e8bf799c2a5b59b8219d64b225424dce22acaa8ee33b90044ebbe8246644eb8"
                }
            };
        }
    }
}
