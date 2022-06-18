using System.ComponentModel.DataAnnotations;

namespace DDD.Application.Contracts.Dtos;

public class UpdateUserRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Message { get; set; }
}