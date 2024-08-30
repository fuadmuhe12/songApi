using SongApi.Entities.Models;

namespace SongApi.Entities.Dtos;

public class CategoryApiMultiResponse
{
    public IEnumerable<Category>? Data { get; set; }
    public string? Error { get; set; }
    public bool IsSuccess { get; set; }
}