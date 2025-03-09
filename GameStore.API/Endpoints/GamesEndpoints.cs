using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static  readonly List<GameSummaryDto> games = [
        new GameSummaryDto(1, "The Witcher 3", "RPG", "The Witcher 3: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.", 29.99m, new DateOnly(2015, 5, 19)),
        new GameSummaryDto(2, "Cyberpunk 2077", "RPG", "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", 59.99m, new DateOnly(2020, 12, 10)),
        new GameSummaryDto(3, "The Elder Scrolls V: Skyrim", "RPG", "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", 19.99m, new DateOnly(2011, 11, 11)),
        new GameSummaryDto(4, "Grand Theft Auto V", "Action", "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", 29.99m, new DateOnly(2013, 9, 17)),
        new GameSummaryDto(5, "Red Dead Redemption 2", "Action", "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", 39.99m, new DateOnly(2018, 10, 26))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games
                     .Include(game => game.Genre)
                     .Select(game => game.ToGameSummaryDto())
                     .AsNoTracking());

        // GET /games/{id}
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) => {
            Game? game = dbContext.Games.Find(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
        });

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) => {
            var existingGame = dbContext.Games.Find(id);
            if (existingGame is null) return Results.NotFound();

            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) => {
            dbContext.Games.Where(game => game.Id == id).ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
