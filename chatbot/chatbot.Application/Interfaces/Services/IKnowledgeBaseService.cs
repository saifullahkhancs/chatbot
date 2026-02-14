using chatbot.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatbot.Application.Interfaces
{
    public interface IKnowledgeBaseService
    {
        Task<IEnumerable<KbArticleDTO>> SearchAsync(string query, string category);
        Task<KbArticleDTO> GetByIdAsync(Guid id);
        Task<KbArticleDTO> CreateAsync(CreateKbArticleDTO dto);
        Task<KbArticleDTO> UpdateAsync(Guid id, CreateKbArticleDTO dto);
        Task DeleteAsync(Guid id);
    }
}