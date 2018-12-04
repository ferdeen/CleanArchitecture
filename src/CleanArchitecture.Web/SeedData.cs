using PaxosExercise.Core.Entities;
using PaxosExercise.Infrastructure.Data;

namespace PaxosExercise.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var toDos = dbContext.MessageItems;
            foreach (var item in toDos)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.MessageItems.Add(new MessageItem()
            {
                Message = "Ferdeen",
                Digest = "94614313b6ab9fc78ff632295ebeb5a4ab993316f6ba0392ceb7811fc4da4435"
            });
            dbContext.MessageItems.Add(new MessageItem()
            {
                Message = "Paxos",
                Digest = "7e8bf799c2a5b59b8219d64b225424dce22acaa8ee33b90044ebbe8246644eb8"
            });
            dbContext.SaveChanges();
        }

    }
}
