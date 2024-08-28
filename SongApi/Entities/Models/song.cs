namespace SongApi.Entities.Models;

public class Song
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public string? Description { get; set; }
    public required string CoverPhotoUrl { get; set; }
    public required string AudioUrl { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly UpdatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}