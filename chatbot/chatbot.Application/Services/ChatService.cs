using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot.Application.Services
{
    public class ChatService : IChatService
    {
        // Temporary in-memory storage for dummy data'[]
        private static readonly List<ConversationDTO> _conversations = new();
        private static readonly List<MessageDTO> _messages = new();

        public Task<AskResponse> AskAsync(AskRequest request, Guid userId)
        {
            // Create new conversation if needed
            var convId = string.IsNullOrEmpty(request.ConversationId)
                ? Guid.NewGuid().ToString()
                : request.ConversationId;

            // Dummy response logic
            var response = new AskResponse
            {
                Answer = $"This is a dummy answer to: '{request.Question}'. In production, this will come from LLM.",
                Source = "HR Policy Manual 2024",
                Confidence = 0.95,
                PolicyDate = DateTime.Now.AddMonths(-1),
                NeedsEscalation = request.Question.ToLower().Contains("complaint") ||
                                  request.Question.ToLower().Contains("escalate"),
                ConversationId = convId
            };

            // Store conversation if new
            if (string.IsNullOrEmpty(request.ConversationId))
            {
                _conversations.Add(new ConversationDTO
                {
                    Id = Guid.Parse(convId),
                    StartedAt = DateTime.Now,
                    MessageCount = 1,
                    LastMessage = request.Question
                });
            }

            // Store messages
            _messages.Add(new MessageDTO
            {
                Id = Guid.NewGuid(),
                Role = "User",
                Content = request.Question,
                CreatedAt = DateTime.Now
            });

            _messages.Add(new MessageDTO
            {
                Id = Guid.NewGuid(),
                Role = "Assistant",
                Content = response.Answer,
                CreatedAt = DateTime.Now
            });

            return Task.FromResult(response);
        }

        public Task<IEnumerable<ConversationDTO>> GetUserConversationsAsync(Guid userId)
        {
            // Return dummy data
            var convos = new List<ConversationDTO>
            {
                new() {
                    Id = Guid.NewGuid(),
                    StartedAt = DateTime.Now.AddDays(-2),
                    MessageCount = 5,
                    LastMessage = "What is the leave policy?"
                },
                new() {
                    Id = Guid.NewGuid(),
                    StartedAt = DateTime.Now.AddDays(-1),
                    MessageCount = 3,
                    LastMessage = "How to apply for sick leave?"
                }
            };

            return Task.FromResult(convos.AsEnumerable());
        }

        public Task<IEnumerable<MessageDTO>> GetConversationMessagesAsync(Guid conversationId, Guid userId)
        {
            // Return dummy messages
            var messages = new List<MessageDTO>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Role = "User",
                    Content = "What is the leave policy?",
                    CreatedAt = DateTime.Now.AddHours(-2)
                },
                new() {
                    Id = Guid.NewGuid(),
                    Role = "Assistant",
                    Content = "Employees are entitled to 24 annual leave days per year...",
                    CreatedAt = DateTime.Now.AddHours(-2).AddMinutes(1)
                }
            };

            return Task.FromResult(messages.AsEnumerable());
        }
    }
}