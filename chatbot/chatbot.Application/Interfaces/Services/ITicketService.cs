using chatbot.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatbot.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDTO> CreateAsync(CreateTicketDTO dto, Guid userId);
        Task<TicketDTO> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(Guid userId);
    }
}