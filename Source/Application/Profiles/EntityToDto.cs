

using AutoMapper;
using DDD.Application.Contracts.Dtos;
using DDD.Domain.Models;

namespace DDD.Application.Profiles;
public class EntityToDto : Profile
{
    public EntityToDto()
    {
        CreateMap<User, UserResponse>();
    }

}