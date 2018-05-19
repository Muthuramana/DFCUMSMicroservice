using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class Step2Model : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public Step2Model(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        [BindProperty]
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        [BindProperty]
        public StepDetail Step { get; set; } = new StepDetail();

        public async Task OnGetAsync()
        {
            Step = await understandMySelfRepository.GetStepByNumber(2);
            SavedAnswer.QuestionId = Step.QuestionId;
            SavedAnswer.SessionId = HttpContext.Session.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await understandMySelfRepository.SaveAnswer(SavedAnswer);

            return RedirectToPage("/Step3");
        }
    }
}
