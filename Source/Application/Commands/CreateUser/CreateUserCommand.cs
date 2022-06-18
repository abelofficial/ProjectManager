using System.ComponentModel.DataAnnotations;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}