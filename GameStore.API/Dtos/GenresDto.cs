using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class GenresDto(
    int Id,
    string Name
);