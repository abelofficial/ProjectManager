using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Application.Contracts;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Commands;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
{
    public IRepository<User> _repo;
    public readonly IMapper _mapper;
    public UpdateUserHandler(IRepository<User> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var updatedUser = _repo.Update(_mapper.Map<User>(request));
        await _repo.SaveChanges();
        return updatedUser;
    }
}