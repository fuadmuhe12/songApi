using SongApi.Entities.Dtos.songDto;
using SongApi.Entities.Models;

namespace SongApi.Interface;

public interface ISongRepository
{
    public Task<IEnumerable<Song>> GetAllSongsAsync();
    public Task<Song?> GetSongByIdAsync(int id);
    public Task<Song?> AddSongAsync(Song song);
    public Task<Song?> UpdateSongAsync(int id ,UpdateSongDto updateSongDto);
    public Task<bool> SongExistsAsync(int id);
    public Task<bool> DeleteSongAsync(int id);
}