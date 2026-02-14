using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KnowledgeBaseController : ControllerBase
    {
        private readonly IKnowledgeBaseService _kbService;

        public KnowledgeBaseController(IKnowledgeBaseService kbService)
        {
            _kbService = kbService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] string category = null)
        {
            var results = await _kbService.SearchAsync(query, category);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var article = await _kbService.GetByIdAsync(id);
            if (article == null)
                return NotFound();
            return Ok(article);
        }

        [HttpPost("articles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateKbArticleDTO dto)
        {
            var article = await _kbService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = article.Id }, article);
        }

        [HttpPut("articles/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateKbArticleDTO dto)
        {
            var article = await _kbService.UpdateAsync(id, dto);
            if (article == null)
                return NotFound();
            return Ok(article);
        }

        [HttpDelete("articles/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _kbService.DeleteAsync(id);
            return NoContent();
        }
    }
}