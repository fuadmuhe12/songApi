using SongApi.Entities.Models;

namespace SongApi.Entities.Dtos.songDto;

public class ViewSongDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public string? Description { get; set; } = string.Empty;
    public required string CoverPhotoUrl { get; set; }
    public required string AudioUrl { get; set; }
    public required Category Category { get; set; }
    public DateOnly CreatedDate { get; set; } 
    public DateOnly UpdatedDate { get; set; } 
}