using PaxosExercise.Core;
using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PaxosExercise.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var items = _repository.List<MessageItem>();
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
