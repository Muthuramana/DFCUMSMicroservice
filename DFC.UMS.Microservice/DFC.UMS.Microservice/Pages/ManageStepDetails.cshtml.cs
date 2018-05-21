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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await understandMySelfRepository.SaveStepDetailsAsync(StepDetail);

            return RedirectToPage("/managestepdetails");
        }
    }
}