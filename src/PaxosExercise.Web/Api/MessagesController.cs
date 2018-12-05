using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using PaxosExercise.Web.ApiModels;
using PaxosExercise.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PaxosExercise.Web.Utilities.ModelStateErrors;
using System;
using PaxosExercise.Web.Utilities.JsonErrors;
using System.Net;
using PaxosExercise.Core;
using System.Threading.Tasks;

namespace PaxosExercise.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class MessagesController : Controller
    {
        private readonly IRepository repository;
        private readonly IMessageDigester messageDigester;

        public MessagesController(IRepository repository, IMessageDigester messageDigester)
        {
            this.repository = repository;
            this.messageDigester = messageDigester;
        }

        [HttpGet("Populate")]
        public IActionResult Populate()
        {
            if (DatabasePopulator.PopulateDatabase(this.repository) > 0)
            {
                var items = this.repository.List<MessageItem>()
                                .Select(MessageItemDTO.FromMessageItem);
                return Ok(items);
            }

            return ErrorHelpers.BuildErrorResponse(HttpStatusCode.BadRequest, "Unable to populate store");
        }

        [HttpGet("GetMessages")]
        public IActionResult List()
        {
            var items = this.repository.List<MessageItem>()
                            .Select(MessageItemDTO.FromMessageItem);
            return Ok(items);
        }        

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = MessageItemDTO.FromMessageItem(this.repository.GetById<MessageItem>(id));
                return Ok(item);
            }
            catch (Exception e)
            {
                return ErrorHelpers.BuildErrorResponse(HttpStatusCode.BadRequest, e.Message, e.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetMessageByDigest(string digest)
        {
            try
            {
                var item = MessageItemDTO.FromMessageItem(this.repository.GetByDigest<MessageItem>(digest));
                return Ok(item.Message);

            }
            catch (Exception)
            {
                return ErrorHelpers.BuildErrorResponse(
                    HttpStatusCode.NotFound, 
                    "Message not found", 
                    $"'{digest}' does not exist in the store, please post a message.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageItemDTO item)
        {
            if (!this.ModelState.IsValid)
            {
                return ModelStateErrors.BuildErrorResponse(this.ModelState);
            }

            try
            {
                var messageItem = new MessageItem()
                {
                    Message = item.Message,
                    Digest = await this.messageDigester.ComputeMessageDigestAsync(item.Message)
                };

                this.repository.Add(messageItem);

                return Ok(MessageItemDTO.FromMessageItem(messageItem));
            }
            catch (Exception e)
            {
                return ErrorHelpers.BuildErrorResponse(HttpStatusCode.BadRequest, e.Message, e.ToString());
            }            
        }
    }
}
