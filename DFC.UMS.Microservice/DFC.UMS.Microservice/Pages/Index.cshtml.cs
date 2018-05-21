using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class IndexModel : BaseStep
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public IndexModel(IUnderstandMySelfRepository understandMySelfRepository) : base(understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
  

        public async Task OnGetAsync()
        {
            await PageSetup(1);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await understandMySelfRepository.SaveAnswerAsync(SavedAnswer);

            return RedirectToPage("/Step2");
        }
    }
}

