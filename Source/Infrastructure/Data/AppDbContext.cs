using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Data;
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
}