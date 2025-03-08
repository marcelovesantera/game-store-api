using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Description = game.Description ?? null,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
    }

    public static GameDto ToDto(this Game game)
    {
        return new GameDto(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Description ?? string.Empty,
                game.Price,
                game.ReleaseDate);
    }
}
