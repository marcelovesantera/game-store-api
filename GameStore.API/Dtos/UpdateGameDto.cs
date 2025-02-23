namespace GameStore.API.Dtos;

public record class UpdateGameDto(
    string Name,
    string Genre,
    string Description,
    decimal Price,
    DateOnly ReleaseDate
);