using SongApi.Entities.Dtos.songDto;
using SongApi.Entities.Models;

namespace SongApi.Entities.Mapper;

public static class SongMapper
{
    //from model to dto
    public static ViewSongDto MapToViewSongDto(this Song song)
    {
        return new ViewSongDto
        {
            Artist = song.Artist,
            Category = song.Category!,
            Title = song.Title,
            AudioUrl = song.AudioUrl,
            CoverPhotoUrl = song.CoverPhotoUrl,
            CreatedDate = song.CreatedDate,
            UpdatedDate = song.UpdatedDate,
            Description = song.Description,
            Id = song.Id,
        };
    }

    public static Song MapToSong(this CreateSongDto createSongDto)
    {
        return new Song
        {
            Artist = createSongDto.Artist,
            Title = createSongDto.Title,
            AudioUrl = createSongDto.AudioUrl,
            CoverPhotoUrl = createSongDto.CoverPhotoUrl,
            CategoryId = createSongDto.CategoryId,
            Description = createSongDto.Description,
        };
    }
}