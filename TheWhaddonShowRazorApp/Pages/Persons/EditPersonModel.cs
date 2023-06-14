using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowRazorApp.Pages.Persons
{
    public class EditPersonModel :Person
    {
        public Person Person { get; set; }
        public bool HasChanged { get; set; } = false;

        public EditPersonModel()
        {
            Person = new Person();
          
        }

        public EditPersonModel(Person person, bool hasChanged)
        {
            Person = person;
            HasChanged = hasChanged;
        }
    }
}
