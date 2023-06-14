using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClassLibrary.LocalServerMethods.Interfaces;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowRazorApp.Pages.Script
{
    public class EditorModel : PageModel
    {
        private readonly ILocalServerModelFactory<ScriptItem, ScriptItemUpdate> _scriptFactory;
        public EditorModel(ILocalServerModelFactory<ScriptItem,ScriptItemUpdate> scriptFactory)
        {
               _scriptFactory = scriptFactory;
        }

        [BindProperty]
        public List<ScriptItem> Script { get; set; } = new List<ScriptItem>();

        public async Task<IActionResult> OnGet()
        {
            Script = await _scriptFactory.CreateModelList();

            Script = Script.OrderBy(x => x.Latest!.OrderNo).ToList();

            return Page();

        }
    }
}
