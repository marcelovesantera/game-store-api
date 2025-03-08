using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class CreateGameDto(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    int GenreId,

    [StringLength(300)]
    string Description,

    [Required]
    [Range(1, 100)]
    decimal Price,

    [Required]
    DateOnly ReleaseDate
);
