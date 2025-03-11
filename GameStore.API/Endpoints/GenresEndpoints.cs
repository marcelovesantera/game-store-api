using GameStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        // GET /genres
        // group.MapGet("/genres", (GameStoreContext dbContext) => 
        //     dbContext.Genres.Select(genre => genre.To))

        return group;
    }
}
