using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _blogpostService;

    public BlogpostsController(BlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogpostDto>>> GetAll()
    {
        var blogposts = await _blogpostService.GetAllAsync();
        return Ok(blogposts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostDto>> GetById(int id)
    {
        var blogpost = await _blogpostService.GetByIdAsync(id);

        if (blogpost == null)
            return NotFound();

        return Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostDto>> Create(BlogpostCreateDto dto)
    {
        var blogpost = await _blogpostService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = blogpost.Id },
            blogpost
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BlogpostUpdateDto dto)
    {
        var success = await _blogpostService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _blogpostService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}