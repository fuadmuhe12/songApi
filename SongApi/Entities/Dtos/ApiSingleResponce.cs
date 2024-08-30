using System.Runtime.InteropServices.JavaScript;
using SongApi.Entities.Dtos.songDto;

namespace SongApi.Entities.Dtos;

public class ApiSingleResponse
{
    public ViewSongDto? Data { get; set; }
    public string? Error { get; set; }
    public bool IsSuccess { get; set; }
}