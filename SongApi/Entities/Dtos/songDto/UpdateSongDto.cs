namespace SongApi.Entities.Dtos.songDto;

public class UpdateSongDto
{
    public  string? Title { get; set; }
    public  string? Artist { get; set; }
    public string? Description { get; set; }
    public  string? CoverPhotoUrl { get; set; }
    public  string? AudioUrl { get; set; }
    public int? CategoryId { get; set; }
    public DateOnly UpdatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}