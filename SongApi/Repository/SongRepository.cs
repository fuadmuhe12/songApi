using Microsoft.EntityFrameworkCore;
using SongApi.Data;
using SongApi.Entities.Dtos.songDto;
using SongApi.Entities.Models;
using SongApi.Interface;

namespace SongApi.Repository;

public class SongRepository(SongContext context) : ISongRepository
{
    private readonly SongContext _context = context;

    public async Task<IEnumerable<Song>> GetAllSongsAsync()
    {
        return await _context.Songs.Include(song => song.Category).ToListAsync();
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

        result.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            

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