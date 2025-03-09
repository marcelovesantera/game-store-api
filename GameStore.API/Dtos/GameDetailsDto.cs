namespace GameStore.API.Dtos;

public record class GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    string? Description,
    decimal Price,
    DateOnly ReleaseDate
);