using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClassLibrary.LocalServerMethods.Interfaces;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowRazorApp.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private ILocalServerModelFactory<Person, PersonUpdate> _personFactory;


        [BindProperty]
        public PersonUpdate PersonUpdate { get; set; }
        
        
        
        public CreateModel(ILocalServerModelFactory<Person,PersonUpdate> personFactory)
        {
            _personFactory = personFactory;
        }
        

        //public async Task OnGet()
        //{

        //}
        //public async Task<IActionResult> OnPost()
        //{
        //     if (ModelState.IsValid == false)
        //    {
        //        return Page();
        //    } 


        //     Person


        //}
    }
}
