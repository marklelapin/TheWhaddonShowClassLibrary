using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClassLibrary.LocalServerMethods.Interfaces;
using System.Data;
using System.Diagnostics.Metrics;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowRazorApp.Pages.Persons
{
    public class EditListModel : PageModel
    {
        private readonly ILocalServerModelFactory<Person, PersonUpdate> _personFactory;
        private readonly ILocalServerModelFactory<Tag, TagUpdate> _tagFactory;


        public EditListModel(ILocalServerModelFactory<Person,PersonUpdate> personFactory,ILocalServerModelFactory<Tag,TagUpdate> tagFactory)
        {
            _personFactory = personFactory;
            _tagFactory = tagFactory;
        }

        [BindProperty]
        public List<EditPersonModel> EditPersons { get; set; } = new List<EditPersonModel>();

        [BindProperty]
        public List<String> TagList { get; set; } = new List<String>();
             
  

        public async Task<IActionResult> OnGet()
        {
            List<Person> persons = await _personFactory.CreateModelList();
            
            persons.ForEach((person) => { EditPersons.Add(new EditPersonModel(person, false)); });

            EditPersons = EditPersons.OrderBy(x => x.Person.Latest!.FirstName).ThenBy(x => x.Person.Latest!.LastName).ToList();

            //add item at bottom of list to add new persons.
            Person newPerson = await _personFactory.CreateModel();
            newPerson.Latest = new PersonUpdate();
            EditPersons.Add(new EditPersonModel(newPerson, false));


            var tags = await _tagFactory.CreateModelList();

            tags.ForEach(tag => TagList.Add(tag.Latest!.Name));

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            
            List<Person> persons = EditPersons.Where(x => x.HasChanged == true).Select(x => x.Person).ToList();

            await _personFactory.SaveModelLatest(persons);

            return RedirectToPage();
            

           
        }
    }
}
