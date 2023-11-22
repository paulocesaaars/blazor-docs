using Deviot.Docs.App.Enums;

namespace Deviot.Docs.App.Models
{
    public class SummaryModel
    {
        public string Title { get; set; }

        public SummaryType SummaryType { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string PathImage { get; set; }
    }
}
