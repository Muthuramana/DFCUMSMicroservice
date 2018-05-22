using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class IndexModel : PageModel
    {
        public string WelcomeMessage { get; set; } = "Welcome to the Understand myself Micro service";

        public void OnGet()
        {
           
        }
    }
}

