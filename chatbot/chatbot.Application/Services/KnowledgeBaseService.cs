using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot.Application.Services
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        // Dummy data
        private static readonly List<KbArticleDTO> _articles = new()
        {
            new() {
                Id = Guid.NewGuid(),
                Question = "How many leave days do I get?",
                Answer = "Employees get 24 annual leave days, 12 sick days, and 5 casual leave days per year.",
                Category = "Leave",
                Source = "HR Policy v2.1"
            },
            new() {
                Id = Guid.NewGuid(),
                Question = "What is the probation period?",
                Answer = "Probation period is 6 months for all new employees.",
                Category = "Employment",
                Source = "HR Policy v2.1"
            }
        };

        public Task<IEnumerable<KbArticleDTO>> SearchAsync(string query, string category)
        {
            var results = _articles
                .Where(a => string.IsNullOrEmpty(category) || a.Category == category)
                .Where(a => a.Question.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Task.FromResult(results.AsEnumerable());
        }

        public Task<KbArticleDTO> GetByIdAsync(Guid id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(article);
        }

        public Task<KbArticleDTO> CreateAsync(CreateKbArticleDTO dto)
        {
            var newArticle = new KbArticleDTO
            {
                Id = Guid.NewGuid(),
                Question = dto.Question,
                Answer = dto.Answer,
                Category = dto.Category,
                Source = dto.Source
            };

            _articles.Add(newArticle);
            return Task.FromResult(newArticle);
        }

        public Task<KbArticleDTO> UpdateAsync(Guid id, CreateKbArticleDTO dto)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                article.Question = dto.Question;
                article.Answer = dto.Answer;
                article.Category = dto.Category;
                article.Source = dto.Source;
            }
            return Task.FromResult(article);
        }

        public Task DeleteAsync(Guid id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                _articles.Remove(article);
            }
            return Task.CompletedTask;
        }
    }
}