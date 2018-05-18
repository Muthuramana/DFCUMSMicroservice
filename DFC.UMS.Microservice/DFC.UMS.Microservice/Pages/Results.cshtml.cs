using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IAnswerRepo answerRepo;

        public ResultsModel(IAnswerRepo answerRepo)
        {
            this.answerRepo = answerRepo;
        }
        public string ResultsMessage { get; set; }

        public IEnumerable<JobProfile> JobProfiles { get; set; }

         
        public void OnGet()
        {
            ResultsMessage = "Results page";
            JobProfiles = new List<JobProfile>{new JobProfile{Title = nameof(JobProfile.Title)}, new JobProfile{ Title = $"{nameof(JobProfile.Title)} - 2"}};
        }
    }
}
