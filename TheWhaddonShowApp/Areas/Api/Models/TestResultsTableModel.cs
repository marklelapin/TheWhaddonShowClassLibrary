using MyApiMonitorClassLibrary.Models;

namespace TheWhaddonShowApp.Areas.Api.Models
{
    public class TestResultsTableModel
    {
        public string? CollectionTitle { get; set; }
        public DateTime? TestDateTime { get; set; }
        public string? TestTitle { get; set; }
        public bool? SuccessFailure { get; set; }
        public string? FailureMessage { get; set; }
        public string? ExpectedResult { get; set; }
        public string? ActualResult { get; set; }


        public TestResultsTableModel(ApiTestData apiTestData)
        {
            CollectionTitle = apiTestData.CollectionTitle;
            TestDateTime = apiTestData.TestDateTime;
            ; TestTitle = apiTestData.TestTitle;
            SuccessFailure = apiTestData.WasSuccessful;
            FailureMessage = apiTestData.FailureMessage;
            ExpectedResult = apiTestData.ExpectedResult;
            ActualResult = apiTestData.ActualResult;
        }


    }
}
