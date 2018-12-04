using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using PaxosExercise.Web.ApiModels;
using PaxosExercise.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PaxosExercise.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class MessageItemsController : Controller
    {
        private readonly IRepository _repository;

        public MessageItemsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<MessageItem>()
                            .Select(MessageItemDTO.FromToDoItem);
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = MessageItemDTO.FromToDoItem(_repository.GetById<MessageItem>(id));
            return Ok(item);
        }

        // GET: api/ToDoItems
        [HttpGet("{digest:string")]
        public IActionResult GetMessageByDigest(string digest)
        {
            var item = MessageItemDTO.FromToDoItem(_repository.GetByDigest<MessageItem>(digest));
            return Ok(item.Message);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post([FromBody] MessageItemDTO item)
        {
            var messageItem = new MessageItem()
            {
                Message = item.Message,
                Digest = item.Digest  // generate digest
            };
            _repository.Add(messageItem);
            return Ok(MessageItemDTO.FromToDoItem(messageItem));
        }
    }
}
