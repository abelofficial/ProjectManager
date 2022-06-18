using System.ComponentModel.DataAnnotations;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}