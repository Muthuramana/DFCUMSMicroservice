using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Models.Framework;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;
        private const string sessionKey = "sessionId";

        public ResultsModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        public string ResultsMessage { get; set; }

        public IEnumerable<JobProfile> JobProfiles { get; set; }

         
        public async Task OnGetAsync()
        {
            ResultsMessage = "Results page";

            var value = HttpContext.Session.GetString(sessionKey);
            var results = await understandMySelfRepository.GetStepsAnswersBySessionId(value);
            var stepAnswers = results as IList<StepAnswer> ?? results.ToList();
            if (stepAnswers.Any())
            {
                JobProfiles = understandMySelfRepository.GetJobProfilesByFilter(new SelectedAnswerFilter
                {
                    AbilityList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("ability"))?.SavedAnswers,
                    SkillList = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("skill"))?.SavedAnswers,
                    TaskItems = stepAnswers.FirstOrDefault(ans => ans.FrameworkItemType.Equals("taskitem"))?.SavedAnswers,
                });
            }
        }
    }
}
