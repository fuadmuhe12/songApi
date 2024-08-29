using SongApi.Entities.Models;

namespace SongApi.Interface;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetCategoriesAsync();
    public Task<bool> CategoryExistsAsync(int id);
}