using System.ComponentModel.DataAnnotations;
using PaxosExercise.Core.Entities;

namespace PaxosExercise.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class MessageItemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public string Digest { get; set; }

        public static MessageItemDTO FromToDoItem(MessageItem item)
        {
            return new MessageItemDTO()
            {
                Id = item.Id,
                Message = item.Message,
                Digest = item.Digest
            };
        }
    }
}
