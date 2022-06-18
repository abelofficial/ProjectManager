using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Contracts;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Queries;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public IRepository<User> _repo;

    public GetAllUsersHandler(IRepository<User> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAll();
    }
}