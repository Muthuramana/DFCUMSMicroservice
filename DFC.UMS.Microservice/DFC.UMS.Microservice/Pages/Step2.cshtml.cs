﻿using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class Step2Model : PageModel
    {
        private readonly IAnswerRepo answerRepo;

        public Step2Model(IAnswerRepo answerRepo)
        {
            this.answerRepo = answerRepo;
        }
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        public StepDetail Step { get; set; }
        public void OnGet()
        {
            Step = answerRepo.GetStepByNumber(2);
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

            return RedirectToPage("/Step3");
        }
    }
}