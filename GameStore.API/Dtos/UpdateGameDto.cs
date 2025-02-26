using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class UpdateGameDto(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    [StringLength(20)]
    string Genre,

    [Required]
    [StringLength(300)]
    string Description,

    [Required]
    [Range(1, 100)]
    decimal Price,

    [Required]
    DateOnly ReleaseDate
);