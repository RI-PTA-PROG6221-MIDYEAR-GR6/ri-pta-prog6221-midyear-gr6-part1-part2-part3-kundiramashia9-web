using System.Collections.Generic;

namespace CyberSecurityChat.Models
{
    public class ChatResponse
    {
        public string[] Keywords { get; set; }
        public string[] Synonyms { get; set; }
        public string[] Responses { get; set; }
        public string Category { get; set; }
        public string Emoji { get; set; }
        public string[] FollowUpQuestions { get; set; }
        public Dictionary<string, string[]> RelatedTopics { get; set; }
    }
}