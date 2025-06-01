
namespace Crawler.tests
{
    public class CsvTests
    {
        [Fact]
        public void CheckWritePage()
        {
            var page = new Page("testUrl", ["one", "two"], ["three", "four"]);
            List<Page> pages = [page, page];
            pages.WriteCsv("pagesTest");
        }
    }
}