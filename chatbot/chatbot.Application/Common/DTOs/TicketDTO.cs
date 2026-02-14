using System;

namespace chatbot.Application.DTOs
{
    public class CreateTicketDTO
    {
        public string Category { get; set; }
        public string Transcript { get; set; }
    }

    public class TicketDTO
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Transcript { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}