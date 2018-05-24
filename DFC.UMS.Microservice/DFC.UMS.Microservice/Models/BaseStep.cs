using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Repositories.Contracts;
using DFC.UMS.Microservice.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFC.UMS.Microservice.Models
{
    public class BaseStep : Controller
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public const string SessionKey = "sessionId";

        public BaseStep(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }

        public async Task PageSetup(StepViewModel stepViewModel, int pageNumber, string sessionId = null)
        {
            stepViewModel.Step = await understandMySelfRepository.GetStepByNumberAsync(pageNumber);
            if (stepViewModel.Step != null)
            {
                var frameworkItemType = stepViewModel.Step.FrameworkItemType?.ToLower();
                switch (frameworkItemType)
                {
                    case "skill":
                        stepViewModel.Answers = understandMySelfRepository.GetAllSkills().Select(skill => skill.Description);
                        break;
                    case "ability":
                        stepViewModel.Answers = understandMySelfRepository.GetAllAbilities().Select(skill => skill.Description);
                        break;
                    case "taskitem":
                        stepViewModel.Answers = understandMySelfRepository.GetAllTaskItems().Select(skill => skill.Description);
                        break;
                }
                stepViewModel.StepAnswer.QuestionId = stepViewModel.Step.QuestionId;
                stepViewModel.StepAnswer.FrameworkItemType = frameworkItemType;
            }
            else
            {
                stepViewModel.Step = new StepDetail();
            }
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                var value = HttpContext.Session.GetString(SessionKey);
                if (string.IsNullOrEmpty(value))
                {
                    value = HttpContext.Session.Id;
                    HttpContext.Session.SetString(SessionKey, value);
                }
                stepViewModel.StepAnswer.SessionId = value;
            }
            else
            {
                stepViewModel.StepAnswer.SessionId = sessionId;
            }
        }
    }
}
