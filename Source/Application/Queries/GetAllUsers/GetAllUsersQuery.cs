using System.Collections.Generic;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {

    }
}