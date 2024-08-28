using Microsoft.AspNetCore.Mvc;

namespace SongApi.Controllers;
[ApiController] 
[Route("[controller]")]
public class SongController:ControllerBase{
    [HttpGet]
    public Task<IActionResult> GetSongs()
    {
        
    }
}