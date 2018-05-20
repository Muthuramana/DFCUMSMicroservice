using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public IndexModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        [BindProperty]
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        [BindProperty]
        public StepDetail Step { get; set; } = new StepDetail();

        public IEnumerable<string> Answers { get; set; }

        public async Task OnGetAsync()
        {
            Step =  await understandMySelfRepository.GetStepByNumberAsync(1);
            switch (Step.FrameworkItemType?.ToLower())
            {
                case "skill":
                    Answers = understandMySelfRepository.GetAllSkills().Select(skill => skill.Description);
                    break;
                case "ability":
                    Answers = understandMySelfRepository.GetAllAbilities().Select(skill => skill.Description);
                    break;
                case "taskitem":
                    Answers = understandMySelfRepository.GetAllTaskItems().Select(skill => skill.Description);
                    break;
            }
            SavedAnswer.QuestionId = Step.QuestionId;
            SavedAnswer.SessionId = HttpContext.Session.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await understandMySelfRepository.SaveAnswerAsync(SavedAnswer);

            return RedirectToPage("/Step2");
        }
    }
}

