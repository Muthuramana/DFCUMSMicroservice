using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Models.Framework;
using DFC.UMS.Microservice.Repositories.Contracts;
using DFC.UMS.Microservice.Services.Contracts;
using DFC.UMS.Microservice.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFC.UMS.Microservice.Controllers
{
    public class StepController : BaseStep
    {
        private readonly IViewRenderService viewRenderService;
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public StepController(IViewRenderService viewRenderService, IUnderstandMySelfRepository understandMySelfRepository): base(understandMySelfRepository)
        {
            this.viewRenderService = viewRenderService;
            this.understandMySelfRepository = understandMySelfRepository;
        }

        [Route("[controller]/{stepNumber}")]
        public async Task<IActionResult> Index(int stepNumber)
        {
            var model = new StepViewModel();
            await PageSetup(model, stepNumber);
            return View(model);
        }

        [HttpPost("[controller]/{stepNumber}")]
        public async Task<IActionResult> Index(StepViewModel model)
        {
            await understandMySelfRepository.SaveAnswerAsync(model.SavedAnswer);

            if (model.SavedAnswer.QuestionId < 3)
            {
                var nextstep = model.SavedAnswer.QuestionId + 1;
                return new RedirectResult($"/step/{nextstep}");
            }
            return new RedirectResult("/step/results");

        }

        [Route("[controller]/results")]
        public async Task<IActionResult> Results()
        {
            var model = new ResultsViewModel
            {
                ResultsMessage = "Results page"
            };

            var value = HttpContext.Session.GetString(SessionKey);
            var results = await understandMySelfRepository.GetStepsAnswersBySessionId(value);
            var stepAnswers = results as IList<StepAnswer> ?? results.ToList();
            if (stepAnswers.Any())
            {
               model.JobProfiles = understandMySelfRepository.GetJobProfilesByFilter(new SelectedAnswerFilter
                {
                    AbilityList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("ability"))?.SavedAnswers,
                    SkillList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("skill"))?.SavedAnswers,
                    TaskItems = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("taskitem"))?.SavedAnswers,
                });
            }

            return View(model);
        }


        [Route("api/[controller]/getstepdetails/{stepnumber}/{sessionid}")]
        public async Task<IDictionary<string, string>> GetAsync(int stepnumber, string sessionId)
        {
            var result = new ConcurrentDictionary<string, string>();

            var model = new StepViewModel();
            await PageSetup(model, stepnumber, sessionId);
         

            var viewString = await viewRenderService.RenderViewToStringAsync("/Views/Step/Index.cshtml", model);

            result.TryAdd($"StepNumber-{stepnumber}", viewString);

            return result;
        }

        [Route("api/[controller]/results/{sessionid}")]
        public async Task<IDictionary<string, string>> GetResultsAsync(string sessionId)
        {
            var result = new ConcurrentDictionary<string, string>();

            var model = new ResultsViewModel
            {
                ResultsMessage = "Results page"
            };
            
            var results = await understandMySelfRepository.GetStepsAnswersBySessionId(sessionId);
            var stepAnswers = results as IList<StepAnswer> ?? results.ToList();
            if (stepAnswers.Any())
            {
                model.JobProfiles = understandMySelfRepository.GetJobProfilesByFilter(new SelectedAnswerFilter
                {
                    AbilityList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("ability"))?.SavedAnswers,
                    SkillList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("skill"))?.SavedAnswers,
                    TaskItems = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("taskitem"))?.SavedAnswers,
                });
            }

            var viewString = await viewRenderService.RenderViewToStringAsync("/Views/Step/Results.cshtml", model);

            result.TryAdd("results", viewString);

            return result;
        }
        
        [HttpPost("api/[controller]/savestepanswer/")]
        public async Task<IDictionary<string, string>> SaveStepAnswersAsync([FromBody]StepAnswer stepAnswer)
        {
            var result = new ConcurrentDictionary<string, string>();

            if (stepAnswer == null)
            {
                result.TryAdd("nextstep", "incorrect input supplied");
                return result;
            }

            await understandMySelfRepository.SaveAnswerAsync(stepAnswer);

            if (stepAnswer.QuestionId < 3)
            {
                var nextstep = stepAnswer.QuestionId + 1;
                result.TryAdd("nextstep", $"api/step/{nextstep}");
            }
            else
            {
                result.TryAdd("nextstep", "api/step/results");
            }

            return result;
        }
    }
}