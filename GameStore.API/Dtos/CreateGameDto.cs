namespace GameStore.API.Dtos;

public record class CreateGameDto(
    string Name,
    string Genre,
    string Description,
    decimal Price,
    DateOnly ReleaseDate
);
