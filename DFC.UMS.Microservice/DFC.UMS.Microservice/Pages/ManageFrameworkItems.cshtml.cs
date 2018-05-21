using System.Threading.Tasks;
using DFC.UMS.Microservice.Models.Framework;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class ManageFrameworkItemsModel : PageModel
    {
        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public ManageFrameworkItemsModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }

        [BindProperty]
        public string TaskList { get; set; }

        [BindProperty]
        public string SkillList { get; set; }

        [BindProperty]
        public string AbilityList { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var skill in SkillList.Split(','))
            {
                await understandMySelfRepository.SaveSkillAsync(new Skill{Description = skill});
            }

            foreach (var ability in AbilityList.Split(','))
            {
                await understandMySelfRepository.SaveAbilityAsync(new Ability { Description = ability });
            }

            foreach (var task in TaskList.Split(','))
            {
                await understandMySelfRepository.SaveTaskItemAsync(new TaskItem { Description = task });
            }

            return RedirectToPage("/manageframeworkItems");
        }
    }
}