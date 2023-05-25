using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClassLibrary.LocalServerMethods.Interfaces;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowRazorApp.Pages.Persons
{
    public class DisplayModel : PageModel
    {
        private readonly ILocalServerModelFactory<Person, PersonUpdate> _personFactory;


        public DisplayModel(ILocalServerModelFactory<Person,PersonUpdate> personFactory)
        {
            _personFactory = personFactory;
        }

        public List<Person> Persons { get; set; }



        public async Task<IActionResult> OnGet()
        {
            Persons = await _personFactory.CreateModelsList();

            return Page();
        }
    }
}
