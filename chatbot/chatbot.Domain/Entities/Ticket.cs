using System;

namespace chatbot.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } // "Open", "InProgress", "Closed"
        public string Transcript { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}