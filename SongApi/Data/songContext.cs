using Microsoft.EntityFrameworkCore;
using SongApi.Entities.Models;
using Models_Song = SongApi.Entities.Models.Song;

namespace SongApi.Data
{
    public class SongContext(DbContextOptions<SongContext> options):DbContext(options)
    {
        public DbSet<Models_Song> Songs => Set<Models_Song>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categories = new List<Category>()
            {
                new Category { Name = "POP" , Id = 1},
                new Category { Name = "Rock", Id = 2},
                new Category { Name = "Jazz", Id = 3}
            };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}