using Microsoft.AspNetCore.Mvc;
using MyApiMonitorClassLibrary.Interfaces;
using MyApiMonitorClassLibrary.Models;
using TheWhaddonShowApp.Areas.Api.Models;

namespace TheWhaddonShowApp.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("Api/[controller]/[action]")]
    public class TestResultsController : Controller
    {
        private readonly IApiTestDataAccess _dataAccess;

        private TestResultsModel TestResultsModel { get; set; } = new TestResultsModel();

        public TestResultsController(IApiTestDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

        }

        public async Task<IActionResult> Index()
        {
            return await All();
        }


        public async Task<IActionResult> All()
        {
            Guid testOrCollectionId = TestResultsModel.TestCollectionOptions["Performance"];
            var model = await GetTestResultsModel(testOrCollectionId);
            return View(model);
        }

        public async Task<IActionResult> Filtered(Guid testOrCollectionId, DateTime? dateFrom = null, DateTime? dateTo = null, int skip = 0, int limit = 100)
        {
            var model = await GetTestResultsModel(testOrCollectionId, dateFrom, dateTo, skip, limit);

            return View(model);
        }



        private async Task<TestResultsModel> GetTestResultsModel(Guid testOrCollectionId, DateTime? dateFrom = null, DateTime? dateTo = null, int skip = 0, int limit = 100)
        {


            dateFrom = dateFrom ?? new DateTime(2023, 8, 1);
            dateTo = dateTo ?? DateTime.Now;

            List<ApiTestData> apiTestData;

            (apiTestData, int totalRecords) = await _dataAccess.GetAllByCollectionId(testOrCollectionId, dateFrom, dateTo, skip, limit);

            if (totalRecords == 0)
            { //if it can't find any using the guid passed in as collection Id then try using it as test Id.

                (apiTestData, totalRecords) = await _dataAccess.GetAllByTestId(testOrCollectionId, dateFrom, dateTo, skip, limit);

            }

            apiTestData = apiTestData.OrderByDescending(x => x.TestDateTime).ToList();

            TestResultsModel output = new();

            output.DateFrom = (DateTime)dateFrom;     //.ToString() ?? string.Empty;
            output.DateTo = (DateTime)dateTo; //.ToString() ?? string.Empty;
            output.CollectionTitle = (apiTestData.Count == 0) ? "" : apiTestData.First().CollectionTitle;
            output.TestResults = apiTestData.Select(x => new TestResultsTableModel(x)).ToList();

            return output;
        }

    }
}
