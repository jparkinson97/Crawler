using HtmlAgilityPack;

namespace Crawler
{
    public static class WebPageReader
    {
        public static Page? GetPageLinks(string url, HashSet<string> visited)
        {
            if (visited.Contains(url))
            {
                return null;
            }
            var web = new HtmlWeb();
            HtmlDocument doc;
            try
            {
                doc = web.Load(url);
            }
            catch (Exception ex)
            {
                return new Page(url, [ex.Message], []);
            }
            List<string> internalLinks = [];
            List<string> externalLinks = [];
            List<string> emails = [];

            Queue<string> queue = new Queue<string>();
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")?? new(new(new(), new(), 0)))
            {
                string hrefValue = link.GetAttributeValue("href", string.Empty);
                if (!visited.Contains(hrefValue))
                {
                    if (hrefValue.Contains("@"))
                    {
                        emails.Add(hrefValue);
                        continue; 
                    }
                    if (hrefValue.StartsWith("http"))
                    {
                        externalLinks.Add(hrefValue);
                    }
                    else
                    {
                        var parentUri = new Uri(url);
                        var combined = new Uri(parentUri, hrefValue);

                        internalLinks.Add(combined.ToString());
                    }
                }
            }
            var page = new Page(url, internalLinks, externalLinks);
            foreach (var email in emails)
            {
                page.Emails.Add(email);
            }

            return page;
        }
    }
}
