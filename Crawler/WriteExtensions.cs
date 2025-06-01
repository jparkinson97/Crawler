using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using CsvHelper;

namespace Crawler
{
    public static class WriteExtensions
    {
        public static void WriteCsv(this List<Page> page, string fileName)
        {
            using (var writer = new StreamWriter($"{fileName}.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(page);
            }
        }

        public static void WriteJSon(this Page page) // todo: make this async?
        {
            string path = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(@"C:\Users\James\source\repos\Crawler\Crawler");
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            var filename = rgx.Replace(page.Url, "_");
            var truncatedFileName = filename.Truncate(20);
            string jsonString = JsonSerializer.Serialize(page);
            File.WriteAllText($"pages/{truncatedFileName}.json", jsonString);
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
