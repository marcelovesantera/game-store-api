using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasData(
            new{ Id = 1, Name = "The Witcher 3", GenreId = 1, Description = "The Witcher 3: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.", Price = 29.99m, ReleaseDate = new DateOnly(2015, 5, 19)},
            new{ Id = 2, Name = "Cyberpunk 2077", GenreId = 1, Description = "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", Price = 59.99m, ReleaseDate = new DateOnly(2020, 12, 10)},
            new{ Id = 3, Name = "The Elder Scrolls V: Skyrim", GenreId = 1, Description = "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", Price = 19.99m, ReleaseDate = new DateOnly(2011, 11, 11)},
            new{ Id = 4, Name = "Grand Theft Auto V", GenreId = 3, Description = "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", Price = 29.99m, ReleaseDate = new DateOnly(2013, 9, 17)},
            new{ Id = 5, Name = "Red Dead Redemption 2", GenreId = 3, Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", Price = 39.99m, ReleaseDate = new DateOnly(2018, 10, 26)}
        );

        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "RPG" },
            new { Id = 2, Name = "Sports" },
            new { Id = 3, Name = "Action" },
            new { Id = 4, Name = "Racing" },
            new { Id = 5, Name = "Fighting" }
        );
    }
}
