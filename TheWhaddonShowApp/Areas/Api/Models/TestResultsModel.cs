

namespace TheWhaddonShowApp.Areas.Api.Models
{
    public class TestResultsModel
    {

        public List<TestResultsTableModel> TestResults { get; set; } = new List<TestResultsTableModel>();

        public Dictionary<string, Guid> TestCollectionOptions { get; set; } = new Dictionary<string, Guid>
        {
            { "Availability",Guid.Parse("c8ecdb94-36a9-4dbb-a5db-e6e036bbba0f") }
            ,{"Performance",Guid.Parse("05b0adac-6ee4-4390-a83b-092ca92b040d") }
        };

        public DateTime DateFrom { get; set; } = DateTime.MinValue;


        public DateTime DateTo { get; set; } = DateTime.Now;

        public string CollectionTitle { get; set; } = "";
    }
}
