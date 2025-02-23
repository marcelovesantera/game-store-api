namespace GameStore.API.Dtos;

public record class GameDto(
    int Id,
    string Name,
    string Genre,
    string Description,
    decimal Price,
    DateOnly ReleaseDate
    );