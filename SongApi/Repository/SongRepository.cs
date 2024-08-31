using Microsoft.EntityFrameworkCore;
using SongApi.Data;
using SongApi.Entities.Dtos.songDto;
using SongApi.Entities.Models;
using SongApi.Helper;
using SongApi.Interface;

namespace SongApi.Repository;

public class SongRepository(SongContext context) : ISongRepository
{
    private readonly SongContext _context = context;

    public async Task<IEnumerable<Song>> GetAllSongsAsync(QueryData queryData)
    {
        var  data = _context.Songs.Include(song => song.Category).AsQueryable();
        if (queryData.CategoryId.HasValue)
        {
            data = data.Where(song => song.CategoryId == queryData.CategoryId);
        }
        
        var final =  await data.ToListAsync();
        var result = final.Where(Song => Song.Id != null);
        if(!string.IsNullOrEmpty(queryData.Search))
        {
            result = final.Where(songdata => songdata.Title.ToLower().Contains(queryData.Search.ToLower()));
        }
        return !string.IsNullOrEmpty(queryData.Search) ? result :final;
    }

    public async Task<Song?> GetSongByIdAsync(int id)
    {
        return await _context.Songs.Include(song => song.Category).FirstOrDefaultAsync(song => song.Id == id);
    }

    public async Task<Song?> AddSongAsync(Song song)
    {
        var result = await _context.Songs.AddAsync(song);
        await _context.SaveChangesAsync();
        var createdSong = result.Entity;
        return await _context.Songs.Include(sg => sg.Category).FirstOrDefaultAsync(sg => sg.Id == createdSong.Id);
    }

    public async Task<Song?> UpdateSongAsync(int id, UpdateSongDto updateSongDto)
    {
        var result = await _context.Songs.Include(song => song.Category).FirstOrDefaultAsync(song => song.Id == id);
        if (result == null)
        {
            return null;
        }

        if (updateSongDto.CategoryId != null)
        {
            result.CategoryId = updateSongDto.CategoryId.Value;
        }

        if (updateSongDto.Description != null)
        {
            result.Description = updateSongDto.Description;
        }

        if (updateSongDto.CoverPhotoUrl != null)
        {
            result.CoverPhotoUrl = updateSongDto.CoverPhotoUrl;
        }

        if (updateSongDto.AudioUrl != null)
        {
            result.AudioUrl = updateSongDto.AudioUrl;
        }

        if (updateSongDto.Artist != null)
        {
            result.Artist = updateSongDto.Artist;
        }

        if (updateSongDto.Title != null)
        {
            result.Title = updateSongDto.Title;
        }

        if (updateSongDto.Duration is not null)
        {
            result.Duration = updateSongDto.Duration.Value;
        }

        result.UpdatedDate = (DateTime.Now);
            

        await _context.SaveChangesAsync();
        return _context.Songs.Include(song => song.Category).FirstOrDefault(song => song.Id == id);
    }
    
    public async Task<bool> SongExistsAsync(int id)
    {
        return await _context.Songs.AnyAsync(song => song.Id == id);
    }

    public async Task<bool> DeleteSongAsync(int id)
    {
        var result = await _context.Songs.Where(song => song.Id == id).ExecuteDeleteAsync();
        return result != 0;
    }
}