﻿using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class Step3Model : PageModel
    {
        private readonly IAnswerRepo answerRepo;

        public Step3Model(IAnswerRepo answerRepo)
        {
            this.answerRepo = answerRepo;
        }
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        public StepDetail Step { get; set; }
        public void OnGet()
        {
            Step = answerRepo.GetStepByNumber(3);
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

            return RedirectToPage("/Results");
        }
    }
}