using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Models
{
    public class BaseStep : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        private const string sessionKey = "sessionId";

        public BaseStep(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        [BindProperty]
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();

        [BindProperty]
        public StepDetail Step { get; set; } = new StepDetail();

        public IEnumerable<string> Answers { get; set; }

        public async Task PageSetup(int pageNumber)
        {
            Step = await understandMySelfRepository.GetStepByNumberAsync(pageNumber);
            if (Step != null)
            {
                var frameworkItemType = Step.FrameworkItemType?.ToLower();
                switch (frameworkItemType)
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
                SavedAnswer.FrameworkItemType = frameworkItemType;
            }
            else
            {
                Step = new StepDetail();
            }

            var value = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                value = HttpContext.Session.Id;
                HttpContext.Session.SetString(sessionKey, value);
            }
            SavedAnswer.SessionId = value;
        }
    }
}
