using System;
using System.Collections.Generic;

namespace chatbot.Domain.Entities
{
    public class ChatConversation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        // Navigation property
        public ICollection<ChatMessage> Messages { get; set; }
    }
}