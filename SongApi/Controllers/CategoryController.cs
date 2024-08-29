using Microsoft.AspNetCore.Mvc;
using SongApi.Interface;

namespace SongApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository):ControllerBase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var result = await _categoryRepository.GetCategoriesAsync();
        return Ok(result);
    }
}