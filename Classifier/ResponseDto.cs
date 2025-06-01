using System.Text.Json.Serialization;

namespace Classifier
{
    public class ApiResponse
    {
        [JsonPropertyName("candidates")]
        public List<Candidate> Candidates { get; set; }
    }
    
    public class Candidate
    {
        [JsonPropertyName("content")]
        public ContentData Content { get; set; }
    }
    
    public class ContentData
    {
        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; }
    }
    
    public class Part
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
