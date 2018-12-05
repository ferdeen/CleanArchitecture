using Microsoft.AspNetCore.Mvc.RazorPages;
using PaxosExercise.Core.Entities;
using PaxosExercise.Core.Interfaces;
using System.Collections.Generic;

namespace PaxosExercise.Web.Pages.ToDoRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public List<MessageItem> MessageItems { get; set; }

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            MessageItems = _repository.List<MessageItem>();
        }
    }
}
