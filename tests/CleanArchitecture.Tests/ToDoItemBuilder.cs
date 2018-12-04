using PaxosExercise.Core.Entities;

namespace PaxosExercise.Tests
{
    public class MessageItemBuilder
    {
        private readonly MessageItem _messageList = new MessageItem();

        public MessageItemBuilder Id(int id)
        {
            _messageList.Id = id;
            return this;
        }

        public MessageItemBuilder Message(string message)
        {
            _messageList.Message = message;
            return this;
        }

        public MessageItemBuilder Digest(string Digest)
        {
            _messageList.Digest = Digest;
            return this;
        }

        public MessageItem Build() => _messageList;
    }
}
