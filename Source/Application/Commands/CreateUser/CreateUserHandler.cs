using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Application.Contracts;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Application.Commands;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    public IRepository<User> _repo;

    public readonly IMapper _mapper;

    public CreateUserHandler(IRepository<User> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var newUser = _mapper.Map<User>(request);
        _repo.Create(newUser);
        await _repo.SaveChanges();
        return newUser;
    }
}