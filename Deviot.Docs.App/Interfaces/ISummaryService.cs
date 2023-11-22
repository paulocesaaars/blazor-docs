using Deviot.Docs.App.Models;

namespace Deviot.Docs.App.Interfaces
{
    public interface ISummaryService
    {
        public void AddDocumentationItem(string title, string url, string description);

        public void AddBlogItem(string title, string url, string description);

        public IEnumerable<SummaryModel> GetItems(string value);
    }
}
