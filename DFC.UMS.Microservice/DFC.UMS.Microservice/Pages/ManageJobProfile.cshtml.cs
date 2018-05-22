using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class ManageJobProfileModel : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public ManageJobProfileModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        [BindProperty]
        public JobProfile JobProfile { get; set; }

        public IEnumerable<string> TaskItems { get; set; }

        public IEnumerable<string> Abilities { get; set; }

        public IEnumerable<string> Skills { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            await understandMySelfRepository.SaveJobProfileAsync(JobProfile);

            return RedirectToPage("/managejobprofile");
        }
        public void OnGet()
        {
            TaskItems = understandMySelfRepository.GetAllTaskItems().Select(item => item.Description);
            Abilities = understandMySelfRepository.GetAllAbilities().Select(item => item.Description);
            Skills = understandMySelfRepository.GetAllSkills().Select(item => item.Description);
        }
    }
}