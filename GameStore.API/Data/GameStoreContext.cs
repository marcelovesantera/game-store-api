using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "RPG" },
            new { Id = 2, Name = "Sports" },
            new { Id = 3, Name = "Action" },
            new { Id = 4, Name = "Racing" },
            new { Id = 5, Name = "Fighting" }
        );
    }
}
