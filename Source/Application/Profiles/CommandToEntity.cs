

using AutoMapper;
using DDD.Application.Commands;
using DDD.Domain.Models;

namespace DDD.Application.Profiles;
public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<UpdateUserCommand, User>();
        CreateMap<CreateUserCommand, User>();
    }

}