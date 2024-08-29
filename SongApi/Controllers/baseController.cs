using Microsoft.AspNetCore.Mvc;

namespace SongApi.Controllers;
[ApiController]
public class BaseController:ControllerBase
{
 [HttpGet]
 [Route("/")]
 public IActionResult Get()
 {
  return Ok("Hello World!");
 }
 
}