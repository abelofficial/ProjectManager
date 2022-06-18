using System.ComponentModel.DataAnnotations;

namespace DDD.Application.Contracts.Dtos;

public class CreateUserRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Message { get; set; }
}