using Deviot.Docs.App.Enums;
using Deviot.Docs.App.Interfaces;
using Deviot.Docs.App.Models;

namespace Deviot.Docs.App.Services
{
    public class SummaryService : ISummaryService
    {
        private List<SummaryModel> _summaryList;

        public SummaryService()
        {
            _summaryList = new List<SummaryModel>();

            AddDocumentationItem("Documentação 1", "/documentation", "Página para documentação 1");

            AddBlogItem("Blog 1", "/blog", "Página para blog 1");
        }

        public void AddDocumentationItem(string title, string url, string description)
        {
            var item = new SummaryModel
            {
                Title = title,
                Url = url,
                Description = description,
                SummaryType = SummaryType.Documentation
            };

            _summaryList.Add(item);
        }

        public void AddBlogItem(string title, string url, string description)
        {
            var item = new SummaryModel
            {
                Title = title,
                Url = url,
                Description = description,
                SummaryType = SummaryType.Blog
            };

            _summaryList.Add(item);
        }

        public IEnumerable<SummaryModel> GetItems(string value)
        {
            return _summaryList.Where(x => x.Description.ToUpper().Contains(value.ToUpper()))
                    .ToList();
        }
    }
}
