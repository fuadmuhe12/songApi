using Microsoft.EntityFrameworkCore;
using SongApi.Data;
using SongApi.Entities.Models;
using SongApi.Interface;

namespace SongApi.Repository;

public class CategoryRepository(SongContext context): ICategoryRepository
{
    private readonly SongContext _context = context;
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<bool> CategoryExistsAsync(int id)
    {
        return await _context.Categories.AnyAsync(x => x.Id == id);
    }
}