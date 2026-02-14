using System;

namespace chatbot.Domain.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public string Role { get; set; } // "User" or "Assistant"
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public ChatConversation Conversation { get; set; }
    }
}