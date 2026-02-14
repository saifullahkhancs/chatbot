using System;

namespace chatbot.Application.DTOs
{
    public class KbSearchRequest
    {
        public string Query { get; set; }
        public string Category { get; set; }
    }

    public class KbArticleDTO
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
    }

    public class CreateKbArticleDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
    }
}