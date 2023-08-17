using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClassLibrary.APITesting.Interfaces;
using MyClassLibrary.APITesting.Models;

namespace TheWhaddonShowAPIMonitor.Pages.Tests
{
    public class ResultsModel : PageModel
    {
        private readonly IAPITestingDataAccess _dataAccess;

        public ResultsModel(IAPITestingDataAccess dataAccess)
        {
           _dataAccess = dataAccess;
        }


        [BindProperty]
        public List<APITestData> TestResults { get; set; } 


        public void OnGet()
        {
            TestResults = _dataAccess.GetAllByTestCollectionId(1);
        }


    }
}
