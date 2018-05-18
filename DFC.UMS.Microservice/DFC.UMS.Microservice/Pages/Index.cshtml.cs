using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAnswerRepo answerRepo;

        public IndexModel(IAnswerRepo answerRepo)
        {
            this.answerRepo = answerRepo;
        }
        [BindProperty]
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        [BindProperty]
        public StepDetail Step { get; set; }

        public void OnGet()
        {
            Step = answerRepo.GetStepByNumber(1);
            SavedAnswer.QuestionId = Step.QuestionId;
            SavedAnswer.SessionId = HttpContext.Session.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await answerRepo.SaveAnswer(SavedAnswer);

            return RedirectToPage("/Step2");
        }
    }
}

