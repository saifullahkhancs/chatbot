using chatbot.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatbot.Application.Interfaces
{
    public interface IChatService
    {
        Task<AskResponse> AskAsync(AskRequest request, Guid userId);
        Task<IEnumerable<ConversationDTO>> GetUserConversationsAsync(Guid userId);
        Task<IEnumerable<MessageDTO>> GetConversationMessagesAsync(Guid conversationId, Guid userId);
    }
}