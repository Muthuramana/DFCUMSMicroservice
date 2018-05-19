using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class ManageStepDetailsModel : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public ManageStepDetailsModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }

        [BindProperty]
        public StepDetail StepDetail { get; set; }

        public IEnumerable<string> TaskItems { get; set; }
        public void OnGet()
        {
            TaskItems = new List<string>{"Travelling", "public speaking", "public relations", "investigative work", "writing"};
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await understandMySelfRepository.SaveStepDetails(StepDetail);

            return Page();
        }
    }
}