using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}