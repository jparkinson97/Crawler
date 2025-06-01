namespace Crawler;
static class Program
{
    public static void Main()
    {
        List<Page> pages = [];
        HashSet<string> visited = [];
        Queue<string> urls = new();
        urls.Enqueue("http://www.textron.com/");

        while (urls.Count > 0)
        {
            var url = urls.Dequeue();
            var page = WebPageReader.GetPageLinks(url, visited);
            visited.Add(url);
            if (page != null)
            {
                pages.Add(page);
                page.WriteJSon();
                foreach (var externalLink in page.ExternalLinks)
                {
                    urls.Enqueue(externalLink);
                }
                foreach (var internalLink in page.InternalLinks)
                {
                    var parentUri = new Uri(url);
                    var combined = new Uri(parentUri, internalLink);
                    //urls.Enqueue(combined.ToString());
                }
            }
            if (urls.Count > 50)
            {
                pages.WriteCsv("pages");
                pages = [];
            }
        }
    }
}
