using SongApi.Entities.Dtos.songDto;

namespace SongApi.Entities.Dtos;

public class ApiMultiResponse
{
        public IEnumerable<ViewSongDto>? Data { get; set; }
        public string? Error { get; set; }
        public bool IsSuccess { get; set; }
}