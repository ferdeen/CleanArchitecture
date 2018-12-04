using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using System.Linq;

namespace PaxosExercise.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository todoRepository)
        {
            if (todoRepository.List<MessageItem>().Any()) return 0;

            todoRepository.Add(new MessageItem
            {
                Message = "bar",
                Digest = "fcde2b2edba56bf408601fb721fe9b5c338d10ee429ea04fae5511b68fbf8fb9"
            });
            todoRepository.Add(new MessageItem
            {
                Message = "Ferdeen",
                Digest = "94614313b6ab9fc78ff632295ebeb5a4ab993316f6ba0392ceb7811fc4da4435"
            });
            todoRepository.Add(new MessageItem
            {
                Message = "Paxos",
                Digest = "7e8bf799c2a5b59b8219d64b225424dce22acaa8ee33b90044ebbe8246644eb8"
            });

            return todoRepository.List<MessageItem>().Count;
        }
    }
}
