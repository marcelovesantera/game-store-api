using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class UpdateGenreDto
(
    [Required]
    [StringLength(50)]
    string Name
);
