
namespace Crawler
{
    public class Page
    {
        public string Url { get; set; }
        public List<string> InternalLinks { get; set; }
        public List<string> ExternalLinks { get; set; }
        public List<string> Emails { get; set; } = [];
        public Page(string url, List<string> internalLinks, List<string> externalLinks) 
        { 
            Url = url;
            InternalLinks = internalLinks;
            ExternalLinks = externalLinks;
        }
    }
}
