using DDD.Application.Contracts;
using DDD.Domain.Models;
using DDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;
public static class Installer
{
    public static void InstallInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMemGymDb"));
        services.AddScoped<IRepository<User>, Repository<User>>();
    }
}
