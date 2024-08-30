using Microsoft.AspNetCore.Mvc;
using SongApi.Entities.Dtos;
using SongApi.Entities.Dtos.songDto;
using SongApi.Entities.Mapper;
using SongApi.Interface;

namespace SongApi.Controllers;
[ApiController] 
[Route("api/[controller]")]
public class SongController(ISongRepository songRepository, ICategoryRepository categoryRepository):ControllerBase
{
    private readonly ISongRepository _songRepository = songRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    [HttpGet]
    public async Task<IActionResult> GetSongs()
    {
        var result = await _songRepository.GetAllSongsAsync();
        var finalView = result.Select(song => song.MapToViewSongDto());
        
        return Ok(new ApiMultiResponse
        {
            IsSuccess = true,
            Data = finalView,
            Error = null
        });
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetSong([FromRoute] int id)
    {
        var result = await _songRepository.GetSongByIdAsync(id);
        if (result == null)
        {
            return NotFound(new ApiSingleResponse
            {
                IsSuccess = false,
                Data = null,
                Error = "the song could not be found."
            });
        }
        var finalView = result.MapToViewSongDto();
        return Ok(new ApiSingleResponse
        {
            IsSuccess = true,
            Data = finalView,
            Error = null
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateSong([FromBody] CreateSongDto createSongDto)
    {
        try
        {
            var categoryExists = await _categoryRepository.CategoryExistsAsync(createSongDto.CategoryId);
            if (!categoryExists)
            {
                return BadRequest(new ApiSingleResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Error = "Category does not exist"
                });
            }
            var newSong = createSongDto.MapToSong();
            var song = await _songRepository.AddSongAsync(newSong);
            return CreatedAtAction(nameof(GetSong), new { id = song?.Id }, new ApiSingleResponse
            {
                IsSuccess = true,
                Data = song?.MapToViewSongDto(),
                Error = null
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ApiSingleResponse{IsSuccess = false, Error = e.Message});
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateSong([FromRoute] int id, [FromBody] UpdateSongDto updateSongDto)
    {
        var songExists = await _songRepository.SongExistsAsync(id);
        if (!songExists)
        {
            return BadRequest( new ApiSingleResponse
            {
                IsSuccess = false,
                Data = null,
                Error = "Song does not exist"
            });
        }

        if (updateSongDto.CategoryId is not null)
        {
            var categoryExists = await _categoryRepository.CategoryExistsAsync(updateSongDto.CategoryId.Value);
            if (!categoryExists)
            {
                return BadRequest(new ApiSingleResponse
                {
                    IsSuccess = false,
                    Error = "Category does not exist",
                    Data = null
                });
            }
        }
        

        var result = await _songRepository.UpdateSongAsync(id, updateSongDto);
        
        return Ok(new ApiSingleResponse
        {
            IsSuccess = true,
            Data = result?.MapToViewSongDto(),
            Error = null
        });
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteSong([FromRoute] int id)
    {
        var result = await _songRepository.DeleteSongAsync(id);
        if (!result)
        {
            return NotFound(new ApiSingleResponse
            {
                IsSuccess = false,
                Error = "Song does not exist",
                Data = null
            });
        }
        return Ok(new ApiSingleResponse
        {
            IsSuccess = true,
            Data = null,
            Error = null
        });
    }
}