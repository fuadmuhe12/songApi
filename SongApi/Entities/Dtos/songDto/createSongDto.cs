using System.ComponentModel.DataAnnotations;

namespace SongApi.Entities.Dtos.songDto;

public class CreateSongDto
{
    public required string Title { get; set; }
    public required string Artist { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }
    public required int Duration { get; set; }
    public required string CoverPhotoUrl { get; set; }
    public required string AudioUrl { get; set; }
    public int CategoryId { get; set; }
}