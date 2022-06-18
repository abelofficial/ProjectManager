

using AutoMapper;
using DDD.Application.Commands;
using DDD.Application.Contracts.Dtos;

namespace DDD.Application.Profiles;
public class DtoToCommand : Profile
{
    public DtoToCommand()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<UpdateUserRequest, UpdateUserCommand>();
    }

}