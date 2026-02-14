using System;
using System.Collections.Generic;

namespace chatbot.Application.DTOs
{
    public class AskRequest
    {
        public string Question { get; set; }
        public string ConversationId { get; set; } // Optional, null for new conversation
    }

    public class AskResponse
    {
        public string Answer { get; set; }
        public string Source { get; set; }
        public double Confidence { get; set; }
        public DateTime? PolicyDate { get; set; }
        public bool NeedsEscalation { get; set; }
        public string ConversationId { get; set; }
    }

    public class ConversationDTO
    {
        public Guid Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int MessageCount { get; set; }
        public string LastMessage { get; set; }
    }

    public class MessageDTO
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}