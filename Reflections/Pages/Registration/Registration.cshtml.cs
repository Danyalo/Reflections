using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reflections.Core.Models;
using Reflections.Data.Promise;

namespace Reflections.Pages.Registration
{
    public class RegistrationModel : PageModel
    {
        private readonly ICitizenRepository citizenRepository;

        [BindProperty]
        public Citizen Citizen { get; set; }

        public RegistrationModel(ICitizenRepository citizenRepository)
        {
            this.citizenRepository = citizenRepository;
        }

        public void OnGet()
        {
            Citizen = new Citizen();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            citizenRepository.Add(Citizen);
            citizenRepository.Commit();

            TempData["Message"] = "Користувача зареєстровано!";
            return RedirectToPage("../Index");
        }
    }
}
