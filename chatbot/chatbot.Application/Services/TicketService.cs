using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot.Application.Services
{
    public class TicketService : ITicketService
    {
        private static readonly List<TicketDTO> _tickets = new();

        public Task<TicketDTO> CreateAsync(CreateTicketDTO dto, Guid userId)
        {
            var ticket = new TicketDTO
            {
                Id = Guid.NewGuid(),
                Category = dto.Category,
                Status = "Open",
                Transcript = dto.Transcript,
                CreatedAt = DateTime.Now
            };

            _tickets.Add(ticket);
            return Task.FromResult(ticket);
        }

        public Task<TicketDTO> GetByIdAsync(Guid id, Guid userId)
        {
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(ticket);
        }

        public Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(Guid userId)
        {
            // Dummy data
            var tickets = new List<TicketDTO>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Category = "HR Query",
                    Status = "Open",
                    Transcript = "Question about leave policy...",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new() {
                    Id = Guid.NewGuid(),
                    Category = "Technical Issue",
                    Status = "Closed",
                    Transcript = "Cannot access payslips...",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    ResolvedAt = DateTime.Now.AddDays(-4)
                }
            };

            return Task.FromResult(tickets.AsEnumerable());
        }
    }
}