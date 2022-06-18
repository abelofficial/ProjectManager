using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Contracts;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Queries;
public class GetUserHandler : IRequestHandler<GetUserQuery, User>
{
    public IRepository<User> _repo;

    public GetUserHandler(IRepository<User> repo)
    {
        _repo = repo;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_repo.GetOne(request.Id));
    }
}