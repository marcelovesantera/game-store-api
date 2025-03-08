using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static  readonly List<GameDto> games = [
        new GameDto(1, "The Witcher 3", "RPG", "The Witcher 3: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.", 29.99m, new DateOnly(2015, 5, 19)),
        new GameDto(2, "Cyberpunk 2077", "RPG", "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", 59.99m, new DateOnly(2020, 12, 10)),
        new GameDto(3, "The Elder Scrolls V: Skyrim", "RPG", "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", 19.99m, new DateOnly(2011, 11, 11)),
        new GameDto(4, "Grand Theft Auto V", "Action", "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", 29.99m, new DateOnly(2013, 9, 17)),
        new GameDto(5, "Red Dead Redemption 2", "Action", "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", 39.99m, new DateOnly(2018, 10, 26))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find(g => g.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(game);
            }).WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                Genre = dbContext.Genres.Find(newGame.GenreId),
                GenreId = newGame.GenreId,
                Description = newGame.Description ?? null,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            GameDto gameDto = new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Description ?? string.Empty,
                game.Price,
                game.ReleaseDate);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, gameDto);
        });

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) => {
            var game = games.Find(g => g.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }

            var index = games.IndexOf(game);
            games[index] = game with
            {
                Name = updatedGame.Name,
                Genre = updatedGame.Genre,
                Description = updatedGame.Description,
                Price = updatedGame.Price,
                ReleaseDate = updatedGame.ReleaseDate
            };

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) => {
            var game = games.Find(g => g.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }

            games.Remove(game);

            return Results.NoContent();
        });

        return group;
    }
}
